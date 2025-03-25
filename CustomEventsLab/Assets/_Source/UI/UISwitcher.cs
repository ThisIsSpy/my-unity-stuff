using System.Collections.Generic;
using UI.Statemachine;
using System;
using UI.UIStates;

namespace UI
{
    public class UISwitcher<T> : IStatemachine where T : UIController
    {
        private readonly Dictionary<Type, T> states;
        private T currentState;

        public UISwitcher(MainMenuController mainMenuController, AddMenuController addMenuController, RemoveMenuController removeMenuController)
        {
            states = new()
            {
                {typeof(MainMenuController), mainMenuController as T },
                {typeof(AddMenuController), addMenuController as T },
                {typeof(RemoveMenuController), removeMenuController as T }
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
