using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Core.GameStates
{
    public class GameStatemachine<T> : IStatemachine where T : GameState
    {
        private readonly Dictionary<Type, T> _states;
        private T _currentState;
        private TextMeshProUGUI stateUI;

        public GameStatemachine(GamingState gamingState, PauseState pauseState, FinalState finalState, TextMeshProUGUI stateUI)
        {
            _states = new()
            {
                {typeof(GamingState), gamingState as T },
                {typeof(PauseState), pauseState as T },
                {typeof (FinalState), finalState as T }
            };
            InitStates();
            this.stateUI = stateUI;
        }
        public void Update()
        {
            if (_currentState != null)
            {
                _currentState.Update();
            }
        }
        private void InitStates()
        {
            foreach (var states in _states)
            {
                states.Value.InjectOwner(this);
            }
        }
        public bool ChangeState<T>() where T : GameState
        {
            if (_states.ContainsKey(typeof(T)))
            {
                _currentState?.Exit();
                _currentState = _states[typeof(T)];
                stateUI.text = _currentState.GetStateName();
                _currentState.Enter();
                return true;
            }
            return false;
        }
    }
}
