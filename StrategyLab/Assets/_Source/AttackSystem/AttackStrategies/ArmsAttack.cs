using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem.AttackStrategies
{
    
    public class ArmsAttack : IAttackStrategy
    {
        private readonly Animator robotAnimator;

        public ArmsAttack(Animator robotAnimator)
        {
            this.robotAnimator = robotAnimator;
        }

        public void ExecuteStrategy()
        {
            robotAnimator.SetTrigger("IsArmAttack");
        }
    }
    
}
