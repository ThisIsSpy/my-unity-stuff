using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.UIStates
{
    public class MainPanelController : UIController
    {
        public MainPanelView MainPanelView { get; private set; }

        public MainPanelController(MainPanelView mainPanelView)
        {
            MainPanelView = mainPanelView;
        }

        public override void Enter()
        {
            MainPanelView.GetComponentInChildren<Button>().interactable = true;
        }

        public override void Exit()
        {
            MainPanelView.GetComponentInChildren<Button>().interactable = false;
        }
    }
}