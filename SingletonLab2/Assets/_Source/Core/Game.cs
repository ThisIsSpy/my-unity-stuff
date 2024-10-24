using ResourceSystem.Data;
using ResourceSystem.View;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core
{
    public class Game
    {
        public event System.Action OnGameOver;
        private readonly List<ResourceButton> buttonList;

        public Game(List<ResourceButton> buttonList)
        {
            this.buttonList = buttonList;
        }

        public void StartGame()
        {
            foreach (ResourceButton button in buttonList)
            {
                button.ActiveTime = ResourceDataService.Instance.SetActiveTime(button.Type);
                button.InactiveTime = ResourceDataService.Instance.SetInactiveTime(button.Type);
                button.StartHalfLife();
            }
        }
        public void GameOver()
        {
            OnGameOver?.Invoke();
        }
    }
}