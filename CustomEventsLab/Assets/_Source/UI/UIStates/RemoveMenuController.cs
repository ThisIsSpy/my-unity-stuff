using System.Collections;
using System.Collections.Generic;
using UI.Statemachine;
using UnityEngine;
using UI.View;

namespace UI.UIStates
{
    public class RemoveMenuController : UIController
    {
        private readonly RemoveMenuView removeMenuPanel;

        public RemoveMenuController(RemoveMenuView removeMenuPanel)
        {
            this.removeMenuPanel = removeMenuPanel;
        }

        public override void Enter()
        {
            removeMenuPanel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            removeMenuPanel.gameObject.SetActive(false);
        }
    }
}