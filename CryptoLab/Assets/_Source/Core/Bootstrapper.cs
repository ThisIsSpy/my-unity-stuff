using Crypto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Wallet;

namespace Core
{   
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private List<CryptoCoinSO> coins;
        [SerializeField] private CryptoWallet wallet;
        [SerializeField] private CurrencyDisplayer currencyWalletDisplayerPrefab;
        [SerializeField] private CurrencyDisplayer currencyShopDisplayerPrefab;
        [SerializeField] private VerticalLayoutGroup currencyShop;
        [SerializeField] private VerticalLayoutGroup currencyWallet;
        private List<CurrencyAgregator> currencyAgregators;

        void Start ()
        {
            currencyAgregators = new();
            for(int i = 0; i < coins.Count; i++)
            {
                GameObject currencyShopDisplayer = Instantiate(currencyShopDisplayerPrefab.gameObject, currencyShop.transform);
                GameObject currencyWalletDisplayer = Instantiate(currencyWalletDisplayerPrefab.gameObject, currencyWallet.transform);
                currencyShopDisplayer.GetComponent<CurrencyDisplayer>().Construct(coins[i], wallet);
                currencyWalletDisplayer.GetComponent<CurrencyDisplayer>().Construct(coins[i], wallet);
                CurrencyAgregator currencyAgregator = new(currencyShopDisplayer.GetComponent<CurrencyDisplayer>(), coins[i]);
                currencyShopDisplayer.GetComponent<CurrencyDisplayer>().InjectCurrencyAgregator(currencyAgregator);
                currencyWalletDisplayer.GetComponent<CurrencyDisplayer>().InjectCurrencyAgregator(currencyAgregator);
                wallet.Coins.Add(new(coins[i], currencyWalletDisplayer.GetComponent<CurrencyDisplayer>().CurrencyPrice));
                currencyAgregators.Add(currencyAgregator);
            }
        }
    }
}