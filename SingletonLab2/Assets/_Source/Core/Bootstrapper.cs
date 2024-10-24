using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ResourceSystem.View;
using UnityEngine.UI;
using TMPro;

namespace Core
{
    public class Bootstrapper : MonoBehaviour
    {
        private Game _game;
        private SceneReseter _reseter;
        public List<ResourceButton> resourceButtons = new();
        public GameOver GameOver;
        public InputListener InputListener;

        public void Awake()
        {
            _game = new(resourceButtons);
            _reseter = new();
            foreach (ResourceButton button in resourceButtons)
            {
                button.Game = _game;
                button.Game.OnGameOver += button.StopAllCoroutines;
                button.Button = button.GetComponent<Button>();
                button.Timer.Game = _game;
                button.Timer.Game.OnGameOver += button.Timer.StopTimer;
                button.Timer.TimerText = button.Timer.GetComponent<TextMeshProUGUI>();
            }
            GameOver.Game = _game;
            GameOver.Game.OnGameOver += GameOver.ShowGameOver;
            GameOver.GameOverText = GameOver.GetComponent<TextMeshProUGUI>();
            InputListener.Reseter = _reseter;
            _game.StartGame();
        }
    }
}