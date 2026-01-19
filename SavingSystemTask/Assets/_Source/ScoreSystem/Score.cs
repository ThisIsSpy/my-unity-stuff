using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int scoreCount;
    public int ScoreCount { get { return scoreCount; } set { scoreCount = value; UpdateUI(); } }

    [SerializeField] private TextMeshProUGUI scoreUI;

    private void UpdateUI()
    {
        scoreUI.text = "Score: " + ScoreCount;
    }
}
