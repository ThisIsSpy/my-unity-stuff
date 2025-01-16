using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem.AttackStrategies
{
    
    public class BombAttack : IAttackStrategy
    {
        private readonly Animator robotAnimator;

        public BombAttack(Animator robotAnimator)
        {
            this.robotAnimator = robotAnimator;
        }

        public void ExecuteStrategy()
        {
            robotAnimator.SetTrigger("IsBombAttack");
        }
    }
    
}
