using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.GameStates
{
    public class GamingState : GameState
    {
        private InputListener inputListener;

        public GamingState(InputListener inputListener)
        {
            this.inputListener = inputListener;
        }

        public override void Enter()
        {
            inputListener.ToggleControls(true);
        }
        public override string GetStateName()
        {
            return "State: Gaming";
        }
        public override void Update()
        {
            Debug.Log("update gaming");
        }
        public override void Exit()
        {
            inputListener.ToggleControls(false);
        }
    }
}