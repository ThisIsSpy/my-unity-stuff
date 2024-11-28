using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.GameStates
{
    public class PauseState : GameState
    {
        public override void Enter()
        {
            Time.timeScale = 0;
        }
        public override string GetStateName()
        {
            return "State: Pause";
        }
        public override void Exit()
        {
            Time.timeScale = 1;
        }
    }
}