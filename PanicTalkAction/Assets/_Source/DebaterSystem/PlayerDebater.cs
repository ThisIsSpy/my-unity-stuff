using Cysharp.Threading.Tasks;
using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PanicTalkAction.DebaterSystem
{
    public class PlayerDebater : MonoBehaviour
    {
        [SerializeField] private EnemyDebater enemyDebater;
        [SerializeField] private Image hpFillImage, tempoIndicator, comboIndicator, missIndicator;
        [SerializeField] private TextMeshProUGUI comboCounter;
        public ReactiveProperty<bool> IsBeat = new(false);
        public bool InTempo;
        [SerializeField] private SerializableReactiveProperty<int> maxHP = new(100);
        public ReactiveProperty<int> HP = new(100);
        private ReactiveProperty<int> combo = new(0);
        private bool isConstructed = false;

        public void Construct()
        {
            HP.Value = maxHP.Value;
            HP.Subscribe(UpdateHPUI).AddTo(this);
            combo.Subscribe(UpdateComboCounterUI).AddTo(this);
            IsBeat.Subscribe(UpdateBeatUI).AddTo(this);
            isConstructed = true;
        }

        private void Update()
        {
            if (!isConstructed) return;
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            { 
                Debug.Log(InTempo);
                if(InTempo)
                {
                    if (Input.GetMouseButton(0)) LockOnStatement();
                    else if (Input.GetMouseButton(1)) enemyDebater.DestroyStatements();
                    combo.Value++;
                }
                else combo.Value = 0;
                DisplayComboIndicatorAsync(InTempo).Forget();
            }
        }

        private void LockOnStatement()
        {
            enemyDebater.CleanList();
            foreach (var attack in enemyDebater.LaunchedVerbalAttacks)
            {
                if (!attack.IsLockedOn)
                {
                    attack.IsLockedOn = true;
                    return;
                }
            }
        }

        private void UpdateHPUI(int value) => hpFillImage.fillAmount = (float)value / maxHP.Value;
        private void UpdateComboCounterUI(int value) => comboCounter.text = value.ToString();

        private void UpdateBeatUI(bool value)
        {
            if (value) tempoIndicator.color = new(1, 1, 1, 1);
            else tempoIndicator.color = new(1, 1, 1, 0.5f);
        }

        private async UniTask DisplayComboIndicatorAsync(bool inTempo)
        {
            if (inTempo)
            {
                missIndicator.gameObject.SetActive(false);
                comboIndicator.gameObject.SetActive(true);
                await UniTask.WaitForSeconds(0.5f);
                comboIndicator.gameObject.SetActive(false);
            }
            else
            {
                comboIndicator.gameObject.SetActive(false);
                missIndicator.gameObject.SetActive(true);
                await UniTask.WaitForSeconds(0.5f);
                missIndicator.gameObject.SetActive(false);
            }
        }

        public void Stop() => isConstructed = false;
    }
}