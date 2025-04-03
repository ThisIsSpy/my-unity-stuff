using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.UIStates
{
    public class MainPanelController : UIController
    {
        private readonly MainPanelView mainPanelView;

        public MainPanelController(MainPanelView mainPanelView)
        {
            this.mainPanelView = mainPanelView;
        }

        public override void Enter()
        {
            //mainPanelView.gameObject.SetActive(true);
            mainPanelView.GetComponentInChildren<Button>().interactable = true;
        }

        public override void Exit()
        {
            //mainPanelView.gameObject.SetActive(false);
            mainPanelView.GetComponentInChildren<Button>().interactable = false;
        }
    }
}