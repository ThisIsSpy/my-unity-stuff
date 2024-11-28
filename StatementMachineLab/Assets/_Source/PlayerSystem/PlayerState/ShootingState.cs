using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

namespace PlayerSystem.PlayerState
{
    public class ShootingState : GameState
    {
        private Object bulletPrefab;
        private Transform firePos;

        public ShootingState(Object bulletPrefab, Transform firePos)
        {
            this.bulletPrefab = bulletPrefab;
            this.firePos = firePos;
        }
        public override void Enter()
        {
            Object bullet = Object.Instantiate(bulletPrefab,firePos.position,Quaternion.identity);
        }
        public override void Update()
        {
            Debug.Log("update shooting");
        }
        public override string GetStateName()
        {
            return "State: Shooting";
        }
        public override void Exit()
        {
            Debug.Log("exit shooting");
        }
    }
}