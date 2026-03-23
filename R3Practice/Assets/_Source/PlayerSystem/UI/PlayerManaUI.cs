using R3;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerSystem.UI
{
    public class PlayerManaUI : MonoBehaviour
    {
        [SerializeField] private PlayerMana playerMana;
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private int manaRestoreAmount;
        [Header("UI Stuff")]
        [SerializeField] private TextMeshProUGUI manaLabel;
        [SerializeField] private Button castSpellButton, restoreManaButton;

        private void Start()
        {
            playerMana.CurrentMana.Subscribe(UpdateUI).AddTo(this);
            playerMana.CurrentMana.Select(x => (float)x / playerMana.MaxMana.CurrentValue > playerMana.LowManaThreshold && playerHealth.CurrentHP.CurrentValue > 0).Subscribe(castSpellButton.gameObject.SetActive).AddTo(this);
            castSpellButton.onClick.AddListener(CastSpell);
            restoreManaButton.onClick.AddListener(RestoreMana);
        }

        private void OnDestroy()
        {
            castSpellButton.onClick.RemoveAllListeners();
            restoreManaButton.onClick.RemoveAllListeners();
        }

        private void UpdateUI(int _) => manaLabel.text = $"{playerMana.CurrentMana.CurrentValue}/{playerMana.MaxMana.CurrentValue} MP";

        private void CastSpell()
        {
            if (playerMana.CurrentMana.CurrentValue < playerMana.SpellCost) return;
            Debug.Log("spell cast");
            playerMana.SetCurrentMana(playerMana.CurrentMana.CurrentValue - playerMana.SpellCost);
        }

        private void RestoreMana() => playerMana.SetCurrentMana(playerMana.CurrentMana.CurrentValue + manaRestoreAmount);
    }
}
