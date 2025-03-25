using System.Collections;
using System.Collections.Generic;
using UI.Statemachine;
using UnityEngine;
using UI.View;

namespace UI.UIStates
{
    public class MainMenuController : UIController
    {
        private readonly MainMenuView mainMenuPanel;

        public MainMenuController(MainMenuView mainMenuPanel)
        {
            this.mainMenuPanel = mainMenuPanel;
        }

        public override void Enter()
        {
            mainMenuPanel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            mainMenuPanel.gameObject.SetActive(false);
        }
    }
}