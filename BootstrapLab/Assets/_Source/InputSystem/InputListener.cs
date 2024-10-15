using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using TMPro.EditorUtilities;

namespace InputSystem
{
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode exitAppKey;
        private Game _game;
        public void Construct(Game game)
        {
            _game = game;
        }
        void Update()
        {
            ListenExitApp();
        }
        private void ListenExitApp()
        {
            if (Input.GetKeyUp(exitAppKey))
            {
                _game.FinishGame();
            }
        }
    }
}