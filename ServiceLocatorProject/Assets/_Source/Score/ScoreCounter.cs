using Services;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Score
{
    
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private bool IsPlayerPrefsSave = true;
        private TextMeshProUGUI scoreText;
        private Button collectButton;
        private int score;
        public int SavedScore { get; private set; }
        private ServiceLocator serviceLocator;

        public int Score { get { return score; } private set { score = value; scoreText.text = score.ToString(); } }

        private void Awake()
        {
            scoreText = GetComponentInChildren<TextMeshProUGUI>();
            collectButton = GetComponentInChildren<Button>();
            SavedScore = 0;
            Score = 0;
            Subscribe();
            StartCoroutine(ScoreAddCoroutine());
        }

        private void Subscribe()
        {
            collectButton.onClick.AddListener(CollectScore);
        }

        void OnDestroy()
        {
            collectButton.onClick.RemoveListener(CollectScore);
        }

        void OnEnable()
        {
            Debug.Log(PlayerPrefs.GetInt("Score", 0));
            StartCoroutine(ScoreAddCoroutine());
        }

        void OnDisable()
        {
            if(IsPlayerPrefsSave)
            {
                if (!serviceLocator.GetService(out PlayerPrefsSaver saver)) { Debug.Log("couldn't find player prefs saver"); return; }
                else saver.SaveScore();
            }
            else
            {
                if (!serviceLocator.GetService(out JSONSaver saver)) { Debug.Log("couldn't find json saver"); return; }
                else saver.SaveScore(Path.Combine(Application.streamingAssetsPath, "Settings.json"));
            }
            StopAllCoroutines();
        }

        public void InjectServiceLocator(ServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public void CollectScore()
        {
            SavedScore += Score;
            Score = 0;
        }

        private IEnumerator ScoreAddCoroutine()
        {
            Score++;
            yield return new WaitForSeconds(1f);
            StartCoroutine(ScoreAddCoroutine());
        }
    }
    
}
