using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Crypto
{
    public class CurrencyAgregator
    {
        private readonly CurrencyDisplayer currencyDisplayer;
        private readonly CryptoCoinSO coin;
        private float price;
        public float Price { get { return price; } 
            private set 
            { 
                price = Mathf.Clamp(value, 0f, float.MaxValue);
                currencyDisplayer.CurrencyPrice.text = $"{Price}$";
            } 
        }

        public CurrencyAgregator(CurrencyDisplayer currencyDisplayer, CryptoCoinSO coin)
        {
            this.currencyDisplayer = currencyDisplayer;
            this.coin = coin;
            Setup();
        }

        private void Setup()
        {
            Price = (coin.PriceRange.MinValue + coin.PriceRange.MaxValue) / 2;
            currencyDisplayer.StartCoroutine(CurrencyPriceUpdateCoroutine());
        }

        private IEnumerator CurrencyPriceUpdateCoroutine()
        {
            yield return new WaitForSeconds(coin.UpdateTime);
            float random = Random.Range(coin.PriceRange.MinValue, coin.PriceRange.MaxValue) * 100;
            int conversion = (int)random;
            random = conversion / 100;
            float diff = random - Price;
            diff *= coin.Coefficient;
            Price += diff;
            currencyDisplayer.StartCoroutine(CurrencyPriceUpdateCoroutine());
        }
    }
}