using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Enemies
{
    
    public class EnemyBerserker : EnemyTemplate
    {
        private int triggerIsBerserkerAttackID;
        private int triggerIsBerserkerAttackStopID;
        public void Construct(Animator enemyAnimator)
        {
            EnemyAnimator = enemyAnimator;
            triggerIsBerserkerAttackID = Animator.StringToHash("IsBerserkerAttack");
            triggerIsBerserkerAttackStopID = Animator.StringToHash("IsBerserkerAttackStop");
        }
        private void OnEnable()
        {
            EnemyMethod();
        }
        private void OnDisable()
        {
            EnemyAnimator.SetTrigger(triggerIsBerserkerAttackStopID);
        }
        protected override void ExecuteAttack()
        {
            if(gameObject.activeSelf == true)
            EnemyAnimator.SetTrigger(triggerIsBerserkerAttackID);
        }
    }
    
}
