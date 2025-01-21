using AttackSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Enemies
{
    
    public class EnemyCopier : EnemyTemplate
    {

        public void Construct(Animator enemyAnimator, AttackPerformer attackPerformer)
        {
            EnemyAnimator = enemyAnimator;
            attackPerformer.OnStrategyExecute += EnemyMethod;
        }
        protected override void ExecuteAttack()
        {
            if(gameObject.activeSelf == true)
            {
                EnemyAnimator.SetTrigger("IsCopierAttack");
            }
        }
    }
    
}
