using Crypto;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Wallet
{
    public class CryptoWallet : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI stableDollarAmountUI;
        [field: SerializeField] public List<CoinSlot> Coins { get; private set; }
        [SerializeField] private float stableDollarAmount;
        public float StableDollarAmount { get { return stableDollarAmount; } 
            set 
            {
                if (value == stableDollarAmount) return;
                stableDollarAmount = Mathf.Clamp(value, 0.0f, float.MaxValue);
                stableDollarAmountUI.text = $"Balance: {stableDollarAmount}$";
            } 
        }
    }

    [Serializable]
    public class CoinSlot
    {
        [SerializeField] private int amount;
        public int Amount { get { return amount; } 
            set 
            { 
                amount = Mathf.Clamp(value, 0, int.MaxValue);
                if(AmountUI != null) AmountUI.text = amount.ToString();
            } 
        }
        public CryptoCoinSO Coin;
        public TextMeshProUGUI AmountUI;


        public CoinSlot(CryptoCoinSO coin, TextMeshProUGUI amountUI)
        {
            Coin = coin;
            AmountUI = amountUI;
            Amount = 0;
        }
    }
}