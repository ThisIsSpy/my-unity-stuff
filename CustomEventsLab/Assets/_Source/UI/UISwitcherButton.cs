using System.Collections;
using System.Collections.Generic;
using UI.Statemachine;
using UI.UIStates;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UISwitcherButton : MonoBehaviour
    {
        [SerializeField] private UISwitcherType uiSwitcherType;
        private Button button;
        private IStatemachine uiSwitcher;

        public void Construct(IStatemachine uiSwitcher)
        {
            this.uiSwitcher = uiSwitcher;
            button = GetComponent<Button>();
            Subscribe();
        }

        private void Subscribe()
        {
            button.onClick.AddListener(SwitchState);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveListener(SwitchState);
        }

        private void SwitchState()
        {
            switch (uiSwitcherType)
            {
                case UISwitcherType.MainMenu:
                    uiSwitcher.ChangeState<MainMenuController>();
                    break;
                case UISwitcherType.AddMenu:
                    uiSwitcher.ChangeState<AddMenuController>();
                    break;
                case UISwitcherType.RemoveMenu:
                    uiSwitcher.ChangeState<RemoveMenuController>();
                    break;
            }
        }
    }

    public enum UISwitcherType
    {
        MainMenu,
        AddMenu,
        RemoveMenu
    }
}