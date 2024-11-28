using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.GameStates
{
    public class FinalState : GameState
    {
        private SpriteRenderer player;
        private InputListener inputListener;

        public FinalState(SpriteRenderer player, InputListener inputListener)
        {
            this.player = player;
            this.inputListener = inputListener;
        }

        public override void Enter()
        {
            inputListener.ToggleControls(false);
            inputListener.DisablePause();
            player.color = new Color(player.color.r,player.color.g,player.color.b, 1f);
        }
        public override string GetStateName()
        {
            return "State: Final";
        }
    }
}