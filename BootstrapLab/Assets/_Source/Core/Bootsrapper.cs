using InputSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScoreSystem;
using TMPro;

namespace Core
{
    public class Bootsrapper : MonoBehaviour
    {
        [SerializeField] private int startScoreValue;
        [SerializeField] private int exitScoreValue;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private ClickableItem stationaryCube;
        [SerializeField] private ClickableItem movingCube;
        [SerializeField] private ScoreText scoreText;
        private Game _game;
        private Score _score;
        void Awake()
        {
            _score = new();
            _game = new(startScoreValue,exitScoreValue,_score);
            stationaryCube.Score = _score;
            movingCube.Score = _score;
            scoreText.Score = _score;
            inputListener.Construct(_game);
            _game.StartGame();
        }
    }
}