using ImprovedTimers;
using R3;
using System.Threading;
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
        private CountdownTimer spellTimer;
        private readonly ReactiveProperty<bool> isSpellReady = new(true);

        private void Start()
        {
            playerMana.CurrentMana.Subscribe(UpdateUI).AddTo(this);
            castSpellButton.onClick.AddListener(CastSpell);
            restoreManaButton.onClick.AddListener(RestoreMana);

            spellTimer = new(playerMana.SpellCooldownTime);
            spellTimer.OnTimerStart += () => isSpellReady.Value = false;
            spellTimer.OnTimerStop += () => isSpellReady.Value = spellTimer.IsFinished;

            Observable.CombineLatest(playerHealth.CurrentHP, playerMana.CurrentMana, isSpellReady, 
                (hp, mana, ready) => hp > 0 && mana >= playerMana.SpellCost && (float)mana / playerMana.MaxMana.CurrentValue > playerMana.LowManaThreshold && ready)
                .Subscribe(castSpellButton.gameObject.SetActive).AddTo(this);
        }

        private void OnDestroy()
        {
            castSpellButton.onClick.RemoveAllListeners();
            restoreManaButton.onClick.RemoveAllListeners();
        }

        private void UpdateUI(int _) => manaLabel.text = $"{playerMana.CurrentMana.CurrentValue}/{playerMana.MaxMana.CurrentValue} MP";

        private void CastSpell()
        {
            if (!isSpellReady.CurrentValue) return;
            if (playerMana.CurrentMana.CurrentValue < playerMana.SpellCost) return;
            playerMana.SetCurrentMana(playerMana.CurrentMana.CurrentValue - playerMana.SpellCost);
            spellTimer.Reset();
            spellTimer.Start();
        }

        private void RestoreMana() => playerMana.SetCurrentMana(playerMana.CurrentMana.CurrentValue + manaRestoreAmount);
    }
}
