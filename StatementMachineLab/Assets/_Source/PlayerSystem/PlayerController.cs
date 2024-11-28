using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerSystem
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerView view;
        private PlayerModel model;

        public void InvokeMove()
        {
            view.Move(model.MoveSpeed);
        }
        public void Construct(PlayerView view, PlayerModel model)
        {
            this.view = view;
            this.model = model;
        }
    }
}
