using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem.AttackStrategies{
    
    public class LaserAttack : IAttackStrategy
    {
        private readonly Animator robotAnimator; 
        public LaserAttack(Animator robotAnimator)
        {
            this.robotAnimator = robotAnimator;
        }
        public void ExecuteStrategy()
        {
            robotAnimator.SetTrigger("IsLaserAttack");
        }
    }
    
}
