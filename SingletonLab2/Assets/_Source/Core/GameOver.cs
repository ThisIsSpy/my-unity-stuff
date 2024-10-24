using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core
{
    public class GameOver : MonoBehaviour
    {
        public TextMeshProUGUI GameOverText;
        public Game Game;

        public void ShowGameOver()
        {
            GameOverText.text = "Game Over.\n Press R to restart";
        }
    }
}