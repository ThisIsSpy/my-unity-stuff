using System.Collections.Generic;
using System;
using Panels.Statemachine;
using Panels.UIStates;

namespace Panels
{
    public class UISwitcher<T> : IStatemachine where T : UIController
    {
        private readonly Dictionary<Type, T> states;
        private T currentState;

        public UISwitcher(MainPanelController mainPanelController, SecondPanelController secondPanelController)
        {
            states = new()
            {
                {typeof(MainPanelController), mainPanelController as T },
                {typeof(SecondPanelController), secondPanelController as T },
            };
            InitStates();
        }

        private void InitStates()
        {
            foreach (var states in states)
            {
                states.Value.InjectOwner(this);
            }
        }

        public bool ChangeState<T>() where T : UIController
        {
            if (states.ContainsKey(typeof(T)))
            {
                currentState?.Exit();
                currentState = states[typeof(T)];
                currentState.Enter();
                return true;
            }
            return false;
        }
    }
}
