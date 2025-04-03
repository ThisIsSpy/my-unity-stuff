using Panels.Statemachine;
using Panels.UIStates;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Panels
{
    public class MainPanelView : MonoBehaviour
    {
        [SerializeField] private Button openButton;
        private IStatemachine uiSwitcher;

        public void Construct(IStatemachine uiSwitcher)
        {
            this.uiSwitcher = uiSwitcher;
        }

        void Awake()
        {
            openButton.onClick.AddListener(Action);
        }

        void OnDestroy()
        {
            openButton.onClick.RemoveListener(Action);
        }

        private void Action()
        {
            uiSwitcher.ChangeState<SecondPanelController>();
        }
    }
}
