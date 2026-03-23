using R3;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMana : MonoBehaviour
    {
        [SerializeField] private SerializableReactiveProperty<int> maxMana = new(100);
        [SerializeField] private SerializableReactiveProperty<int> currentMana = new(100);
        [field: Range(0.1f, 0.99f), SerializeField] public float LowManaThreshold { get; private set; }
        [field: SerializeField] public int SpellCost { get; private set; }
        public ReadOnlyReactiveProperty<int> MaxMana => maxMana;
        public ReadOnlyReactiveProperty<int> CurrentMana => currentMana;

        public void SetCurrentMana(int value) => currentMana.Value = Mathf.Clamp(value, 0, maxMana.Value);

        private void OnDestroy()
        {
            maxMana.Dispose();
            currentMana.Dispose();
        }
    }
}
