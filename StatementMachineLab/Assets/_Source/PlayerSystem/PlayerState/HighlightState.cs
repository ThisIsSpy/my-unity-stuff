using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace PlayerSystem.PlayerState
{
    public class HighlightState : GameState
    {
        private SpriteRenderer circle;
        public HighlightState(SpriteRenderer circle)
        {
            this.circle = circle;
        }

        public override void Enter()
        {
            circle.enabled = true;
        }
        public override void Update()
        {
            Debug.Log("update highlight");
        }
        public override string GetStateName()
        {
            return "State: Highlight";
        }
        public override void Exit()
        {
            circle.enabled = false;
        }
    }
}
