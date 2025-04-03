using Panels.Statemachine;
using Panels.UIStates;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Panels
{
    
    public class SecondPanelView : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        private IStatemachine uiSwitcher;

        public void Construct(IStatemachine uiSwitcher)
        {
            this.uiSwitcher = uiSwitcher;
        }

        void Awake()
        {
            closeButton.onClick.AddListener(Action);
        }

        void OnDestroy()
        {
            closeButton.onClick.RemoveListener(Action);
        }

        private void Action()
        {
            uiSwitcher.ChangeState<MainPanelController>();
        }
    }
    
}
