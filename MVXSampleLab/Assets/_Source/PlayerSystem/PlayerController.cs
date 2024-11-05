using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerController : MonoBehaviour
    {
        public PlayerView playerView;

        public void BootstrapAwake()
        {
            PlayerModel.OnHealthChange += playerView.PlayerSpriteChangeOnHPChange;
            PlayerModel.OnHealthChange += playerView.DisplayHP;
            PlayerModel.OnPlayerDeath += playerView.PlayerSpriteChangeOnPlayerDeath;
            PlayerModel.OnPlayerDeath += playerView.DisplayHP;
        }
    }
}
