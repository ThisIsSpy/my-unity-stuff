using ImprovedTimers;
using PanicTalkAction.PanicTalkActionSystem;
using R3;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace PanicTalkAction.DebaterSystem
{
    public class EnemyDebater : MonoBehaviour
    {
        [SerializeField] private VerbalAttack verbalAttackPrefab;
        [SerializeField] private List<VerbalAttackSettings> verbalAttackList;
        [SerializeField] private List<Sprite> enemyImages;
        [SerializeField] private Sprite enemyDefeatedImage;
        [SerializeField] private List<Transform> spawnPoints;
        [SerializeField] private Transform verbalAttackParent;
        [SerializeField] private Image opponentDisplayer;
        [SerializeField] private Image hpFillImage;
        [SerializeField] private AudioSource sfxSource;
        private CountdownTimer verbalAttackTimer;
        private CountdownTimer imageChangeTimer;
        private readonly List<VerbalAttack> launchedVerbalAttacks = new();
        [SerializeField] private SerializableReactiveProperty<int> maxHP = new(500);
        public ReactiveProperty<int> HP = new(500);
        public IReadOnlyList<VerbalAttack> LaunchedVerbalAttacks => launchedVerbalAttacks;
        private int lastUsedSpawnPoint = -1;
        private int lastUsedVerbalAttack = -1;
        private int lastUsedDebaterImage = -1;
        private bool isStopped = false;

        public void Construct()
        {
            HP.Value = maxHP.CurrentValue;
            HP.Subscribe(UpdateUI).AddTo(this);

            verbalAttackTimer = new(Random.Range(2, 5));
            verbalAttackTimer.OnTimerStop += SpawnVerbalAttack;
            verbalAttackTimer.Start();

            imageChangeTimer = new(Random.Range(5, 10));
            imageChangeTimer.OnTimerStop += ChangeDebaterImage;
            imageChangeTimer.Start();
        }

        private void SpawnVerbalAttack()
        {
            if(isStopped) return;
            int spawnPointIndex = lastUsedSpawnPoint;
            while (spawnPointIndex == lastUsedSpawnPoint)
            {
                spawnPointIndex = Random.Range(0, spawnPoints.Count);
            }
            lastUsedSpawnPoint = spawnPointIndex;
            Transform spawnPoint = spawnPoints[spawnPointIndex];
            GameObject wordTarget = Instantiate(verbalAttackPrefab.gameObject, spawnPoint.position, Quaternion.identity, verbalAttackParent);

            int verbalAttackIndex = lastUsedVerbalAttack;
            while (verbalAttackIndex == lastUsedVerbalAttack)
            {
                verbalAttackIndex = Random.Range(0, verbalAttackList.Count);
            }
            lastUsedVerbalAttack = verbalAttackIndex;
            VerbalAttackSettings verbalAttack = verbalAttackList[verbalAttackIndex];
            wordTarget.GetComponentInChildren<TextMeshProUGUI>().text = verbalAttack.text;
            sfxSource.PlayOneShot(verbalAttack.voiceLine);
            launchedVerbalAttacks.Add(wordTarget.GetComponent<VerbalAttack>());

            verbalAttackTimer.Reset(Random.Range(2, 5));
            verbalAttackTimer.Start();
        }

        private void ChangeDebaterImage()
        {
            if(isStopped) return;
            int debaterImageIndex = lastUsedDebaterImage;
            while (debaterImageIndex == lastUsedDebaterImage)
            {
                debaterImageIndex = Random.Range(0, enemyImages.Count);
            }
            lastUsedDebaterImage = debaterImageIndex;
            opponentDisplayer.sprite = enemyImages[debaterImageIndex];
            imageChangeTimer.Reset(Random.Range(5, 10));
            imageChangeTimer.Start();
        }

        private void UpdateUI(int value) => hpFillImage.fillAmount = (float)value / maxHP.Value;

        public void DestroyStatements()
        {
            CleanList();
            foreach (var attack in launchedVerbalAttacks)
            {
                if (attack.IsLockedOn)
                {
                    Destroy(attack.gameObject);
                    HP.Value -= 25;
                }
            }
        }

        public void AcceptDefeat() => opponentDisplayer.sprite = enemyDefeatedImage;

        public void CleanList() => launchedVerbalAttacks.RemoveAll(item => item == null);

        public void Stop()
        {
            isStopped = true;
            imageChangeTimer.Stop();
            verbalAttackTimer.Stop();
            foreach(var attack in launchedVerbalAttacks) Destroy(attack.gameObject);
            CleanList();
        }
    }

    [Serializable]    
    public struct VerbalAttackSettings
    {
        public string text;
        public AudioClip voiceLine;

        public VerbalAttackSettings(string text, AudioClip voiceLine)
        {
            this.text = text;
            this.voiceLine = voiceLine;
        }
    }
}