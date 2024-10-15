using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreText : MonoBehaviour
    {
        public Score Score;
        private TextMeshProUGUI _text;

        private void Start()
        {
            _text = GetComponent<TextMeshProUGUI>();
            _text.text = $"{Score.ScoreValue}";
            Score.ScoreChange += ScoreTextChange;
        }
        private void ScoreTextChange()
        {
            _text.text = $"{Score.ScoreValue}";
        }
    }
}