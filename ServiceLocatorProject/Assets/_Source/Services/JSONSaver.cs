using Score;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Services
{
    public class JSONSaver : ISaver
    {
        private readonly ScoreCounter scoreCounter;

        public JSONSaver(ScoreCounter scoreCounter)
        {
            this.scoreCounter = scoreCounter;
        }

        public void SaveScore(string path = null)
        {
            File.WriteAllText(path, JsonUtility.ToJson(scoreCounter.SavedScore));
        }
    }
}
