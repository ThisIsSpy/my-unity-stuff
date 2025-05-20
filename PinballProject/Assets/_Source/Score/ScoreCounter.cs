using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Xml.Schema;

namespace Score
{
    public class ScoreCounter : MonoBehaviour
    {
        private TextMeshProUGUI scoreUI;
        private int score;
        public int Score { get { return score; } 
            set 
            {
                if (value == score) return;
                score = value;
                if (scoreUI != null) scoreUI.text = $"Score: {score}";
            } 
        }


        void Start()
        {
            scoreUI = GetComponent<TextMeshProUGUI>();
            scoreUI.text = "Score: 0";
        }


    }
}