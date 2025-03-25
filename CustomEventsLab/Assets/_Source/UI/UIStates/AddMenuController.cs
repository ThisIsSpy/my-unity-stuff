using System.Collections;
using System.Collections.Generic;
using UI.Statemachine;
using UnityEngine;
using UI.View;

namespace UI.UIStates
{
    public class AddMenuController : UIController
    {
        private readonly AddMenuView addMenuPanel;

        public AddMenuController(AddMenuView addMenuPanel)
        {
            this.addMenuPanel = addMenuPanel;
        }
        public override void Enter()
        {
            addMenuPanel.gameObject.SetActive(true);
        }

        public override void Exit()
        {
            addMenuPanel.gameObject.SetActive(false);
        }
    }
}