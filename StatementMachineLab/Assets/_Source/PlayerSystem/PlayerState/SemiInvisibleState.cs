using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace PlayerSystem.PlayerState
{
    public class SemiInvisibleState : GameState
    {
        private SpriteRenderer player;

        public SemiInvisibleState(SpriteRenderer player)
        {
            this.player = player;
        }

        public override void Enter()
        {
            //player.color = Color.green;
            player.color = new Color(player.color.r,player.color.g,player.color.b, 0.25f);
        }
        public override void Update()
        {
            Debug.Log("update semi-invisible");
        }
        public override string GetStateName()
        {
            return "String: Semi-Invisible";
        }
        public override void Exit()
        {
            //player.color = Color.white;
            player.color = new Color(player.color.r, player.color.g, player.color.b, 255f);
        }
    }
}