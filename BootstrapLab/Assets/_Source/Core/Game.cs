using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScoreSystem;

namespace Core
{
    public class Game
    {
        private readonly int _startScoreValue;
        private readonly int _exitScoreValue;
        private readonly Score _score;
        public Game(int startScoreValue, int exitScoreValue, Score score)
        {
            _startScoreValue = startScoreValue;
            _exitScoreValue = exitScoreValue;
            _score = score;
        }
        public void StartGame()
        {
            _score.SetScore(_startScoreValue);
        }
        public void FinishGame()
        {
            _score.SetScore(_exitScoreValue);
        }
    }
}
