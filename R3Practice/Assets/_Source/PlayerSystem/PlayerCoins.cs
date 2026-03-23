using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerCoins : MonoBehaviour
    {
        [SerializeField] private int maxCoins = 9999;
        [SerializeField] private SerializableReactiveProperty<int> coins = new(100);

        public ReadOnlyReactiveProperty<int> Coins => coins;

        public void SetCoins(int value) => coins.Value = Mathf.Clamp(value, 0, maxCoins);

        private void OnDestroy()
        {
            coins.Dispose();
        }
    }
}