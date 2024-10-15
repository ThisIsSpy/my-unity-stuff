using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    public class Score
    {
        public int ScoreValue { get; private set; }
        public event System.Action ScoreChange;
        public void SetScore(int value)
        {
            ScoreValue = value;
            ScoreChange?.Invoke();
        }
        public void AddScore(int score)
        {
            ScoreValue += score;
            ScoreChange?.Invoke();
        }
    }
}
