using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerSystem.UI
{
    public class PlayerHealthUI : MonoBehaviour
    {
        [SerializeField] private PlayerHealth playerHealth;
        [SerializeField] private int damageAmount;
        [Header("UI Stuff")]
        [SerializeField] private Image gameOverScreen;
        [SerializeField] private TextMeshProUGUI healthLabel, lowHPWarningSign, medkitsAmountLabel;
        [SerializeField] private Button healButton, damageButton;

        private void Start()
        {
            playerHealth.MaxHP.Subscribe(UpdateUI).AddTo(this);
            playerHealth.CurrentHP.Subscribe(UpdateUI).AddTo(this);
            playerHealth.CurrentHP.Select(hp => (float)hp / playerHealth.MaxHP.CurrentValue < playerHealth.LowHPThreshold).Subscribe(lowHPWarningSign.gameObject.SetActive).AddTo(this);
            playerHealth.CurrentHP.Select(hp => hp < 1).Subscribe(gameOverScreen.gameObject.SetActive).AddTo(this);
            playerHealth.MedkitAmount.Subscribe(x => medkitsAmountLabel.text = $"{x} medkits left").AddTo(this);
            playerHealth.MedkitAmount.Select(value => value > 0).Subscribe(healButton.gameObject.SetActive).AddTo(this);
            healButton.onClick.AddListener(UseMedkit);
            damageButton.onClick.AddListener(Damage);
        }

        private void OnDestroy()
        {
            healButton.onClick.RemoveAllListeners();
            damageButton.onClick.RemoveAllListeners();
        }

        private void UpdateUI(int _) => healthLabel.text = $"{playerHealth.CurrentHP.CurrentValue}/{playerHealth.MaxHP.CurrentValue} HP";

        private void UseMedkit()
        {
            if (playerHealth.MedkitAmount.CurrentValue < 1 || playerHealth.CurrentHP.CurrentValue == playerHealth.MaxHP.CurrentValue) return;
            playerHealth.SetCurrentHP(playerHealth.CurrentHP.CurrentValue + playerHealth.MedkitHealAmount);
            playerHealth.SetMedkitAmountValue(playerHealth.MedkitAmount.CurrentValue - 1);
        }

        private void Damage() => playerHealth.SetCurrentHP(playerHealth.CurrentHP.CurrentValue - damageAmount);
    }
}