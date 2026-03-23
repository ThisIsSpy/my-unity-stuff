using R3;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerSystem.UI
{
    public class PlayerCoinsUI : MonoBehaviour
    {
        [SerializeField] private PlayerCoins playerCoins;
        [SerializeField] private int spendAmount, getAmount;
        [Header("UI Stuff")]
        [SerializeField] private TextMeshProUGUI coinsLabel;
        [SerializeField] private Button spendMoneyButton, getMoneyButton;

        private void Start()
        {
            playerCoins.Coins.Subscribe(x => coinsLabel.text = $"{x} coins").AddTo(this);
            spendMoneyButton.onClick.AddListener(SpendMoney);
            getMoneyButton.onClick.AddListener(GetMoney);
        }

        private void OnDestroy()
        {
            spendMoneyButton.onClick.RemoveAllListeners();
            getMoneyButton.onClick.RemoveAllListeners();
        }

        private void SpendMoney() => playerCoins.SetCoins(playerCoins.Coins.CurrentValue - spendAmount);
        private void GetMoney() => playerCoins.SetCoins(playerCoins.Coins.CurrentValue + getAmount);
    }
}