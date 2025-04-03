using Services;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Score
{
    
    public class ScoreCounter : MonoBehaviour
    {
        private TextMeshProUGUI scoreText;
        private Button collectButton;
        private int score;
        public int SavedScore { get; private set; }
        private ISaver saver;

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

        [Inject]
        public void Construct(ISaver saver)
        {
            this.saver = saver;
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
            saver.SaveScore(Path.Combine(Application.streamingAssetsPath, "Settings.json"));
            StopAllCoroutines();
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
