using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Wallet;

namespace Crypto
{
    public class CurrencyDisplayer : MonoBehaviour
    {
        [SerializeField] private Image currencyIcon;
        [SerializeField] private TextMeshProUGUI currencyName;
        [field: SerializeField] public TextMeshProUGUI CurrencyPrice { get; private set; }
        [SerializeField] private Button currencyBuyButton;
        [SerializeField] private Button currencySellButton;
        [SerializeField] private bool isShopDisplayer;
        private CryptoCoinSO coin;
        private CryptoWallet wallet;
        private CurrencyAgregator currencyAgregator;

        void OnDestroy()
        {
            currencyBuyButton.onClick.RemoveAllListeners();
        }

        public void Construct(CryptoCoinSO coin, CryptoWallet wallet)
        {
            this.coin = coin;
            this.wallet = wallet;
            currencyIcon.sprite = coin.Icon;
            currencyName.text = coin.Name;
            if (isShopDisplayer)
            {
                currencyBuyButton.gameObject.SetActive(true);
                currencySellButton.gameObject.SetActive(false);
                currencyBuyButton.onClick.AddListener(BuyCurrency);
                CurrencyPrice.text = "0$";
            }
            else
            {
                currencyBuyButton.gameObject.SetActive(false);
                currencySellButton.gameObject.SetActive(true);
                currencySellButton.onClick.AddListener(SellCurrency);
                CurrencyPrice.text = "0";
            }
        }

        public void InjectCurrencyAgregator(CurrencyAgregator currencyAgregator)
        {
            this.currencyAgregator = currencyAgregator;
        }

        public void BuyCurrency()
        {
            if (wallet.StableDollarAmount < currencyAgregator.Price)
            {
                Debug.Log("Not enough money to buy");
                return;
            }
            wallet.StableDollarAmount -= currencyAgregator.Price;
            for (int i = 0; i < wallet.Coins.Count; i++)
            {
                if (wallet.Coins[i].Coin == coin)
                {
                    wallet.Coins[i].Amount++;
                    return;
                }
            }
        }

        public void SellCurrency()
        {
            for (int i = 0; i < wallet.Coins.Count; i++)
            {
                if (wallet.Coins[i].Coin == coin && wallet.Coins[i].Amount > 0)
                {
                    wallet.Coins[i].Amount--;
                    wallet.StableDollarAmount += currencyAgregator.Price;
                    return;
                }
            }
            Debug.Log("No currency to sell");
        }
    }
}