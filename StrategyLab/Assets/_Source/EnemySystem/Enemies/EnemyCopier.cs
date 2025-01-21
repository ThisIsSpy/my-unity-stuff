using AttackSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Enemies
{
    
    public class EnemyCopier : EnemyTemplate
    {
        private int triggerIsCopierAttackID;
        private AttackPerformer attackPerformer;
        public void Construct(Animator enemyAnimator, AttackPerformer attackPerformer)
        {
            EnemyAnimator = enemyAnimator;
            this.attackPerformer = attackPerformer;
            this.attackPerformer.OnStrategyExecute += EnemyMethod;
            triggerIsCopierAttackID = Animator.StringToHash("IsCopierAttack");
        }
        private void OnDestroy()
        {
            attackPerformer.OnStrategyExecute -= EnemyMethod;
        }
        protected override void ExecuteAttack()
        {
            if(gameObject.activeSelf == true)
            {
                EnemyAnimator.SetTrigger(triggerIsCopierAttackID);
            }
        }
    }
    
}
