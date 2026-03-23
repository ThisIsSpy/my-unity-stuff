using R3;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerHealth : MonoBehaviour
    {
        [Header("Player Health Stuff")]
        [SerializeField] private SerializableReactiveProperty<int> maxHP = new(100);
        [SerializeField] private SerializableReactiveProperty<int> currentHP = new(100);
        [field: Range(0.1f, 0.99f), SerializeField] public float LowHPThreshold { get; private set; }

        [Header("Medkit stuff")]
        [SerializeField] private int medkitMaxAmount = 10;
        [SerializeField] private SerializableReactiveProperty<int> medkitAmount = new(10);
        [field: SerializeField] public int MedkitHealAmount { get; private set; }

        public ReadOnlyReactiveProperty<int> MaxHP => maxHP;
        public ReadOnlyReactiveProperty<int> CurrentHP => currentHP;
        public ReadOnlyReactiveProperty<int> MedkitAmount => medkitAmount;

        public void SetCurrentHP(int value) => currentHP.Value = Mathf.Clamp(value, 0, maxHP.Value);
        public void SetMedkitAmountValue(int value) => medkitAmount.Value = Mathf.Clamp(value, 0, medkitMaxAmount);

        private void OnDestroy()
        {
            maxHP.Dispose();
            currentHP.Dispose();
            medkitAmount.Dispose();
        }
    }
}
