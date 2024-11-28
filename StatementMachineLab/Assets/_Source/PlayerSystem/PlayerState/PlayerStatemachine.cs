using PlayerSystem.PlayerState;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Core;
using UnityEngine;

namespace PlayerSystem.PlayerState
{
    public class PlayerStatemachine<T> : IStatemachine where T : GameState
    {
        private readonly Dictionary<Type, T> _states;
        private T _currentState;
        private TextMeshProUGUI stateText;
        public PlayerStatemachine(ShootingState shootingState, HighlightState highlightState, SemiInvisibleState semiInvisibleState, TextMeshProUGUI stateText)
        {
            _states = new()
            {
                {typeof(ShootingState), shootingState as T },
                {typeof(HighlightState), highlightState as T },
                {typeof(SemiInvisibleState), semiInvisibleState as T }
            };
            InitStates();
            this.stateText = stateText;
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
            foreach(var states in _states)
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
                _currentState.Enter();
                stateText.text = _currentState.GetStateName();
                return true;
            }
            return false;
        }
    }
}