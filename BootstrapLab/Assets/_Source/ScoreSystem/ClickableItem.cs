using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScoreSystem
{
    public class ClickableItem : MonoBehaviour
    {
        [SerializeField] private int increment;
        public Score Score;
        private void OnMouseDown()
        {
            Score.AddScore(increment);
        }
    }
}