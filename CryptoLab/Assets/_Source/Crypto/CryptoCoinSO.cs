using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Crypto
{
    [CreateAssetMenu(fileName = "CryptoCoinSO", menuName = "SO/New Crypto Coin SO", order = 0)]
    public class CryptoCoinSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Range PriceRange { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField, Range(0,1)] public float Coefficient { get; private set; }
        [field: SerializeField] public float UpdateTime { get; private set; }
    }

    [Serializable]
    public struct Range
    {
        public float MinValue;
        public float MaxValue;

        public Range(float minValue, float maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
    }
}