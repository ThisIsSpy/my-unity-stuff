using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Score;

namespace Services
{
    public class PlayerPrefsSaver : ISaver
    {
        private readonly ScoreCounter scoreCounter;

        public PlayerPrefsSaver(ScoreCounter scoreCounter)
        {
            this.scoreCounter = scoreCounter;
        }
        public void SaveScore(string path = null)
        {
            PlayerPrefs.SetInt("Score", scoreCounter.SavedScore);
        }
    }

}