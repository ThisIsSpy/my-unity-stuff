using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Enemies
{
    
    public class EnemyBerserker : EnemyTemplate
    {
        public void Construct(Animator enemyAnimator)
        {
            EnemyAnimator = enemyAnimator;
        }
        private void OnEnable()
        {
            EnemyMethod();
        }
        private void OnDisable()
        {
            EnemyAnimator.SetTrigger("IsBerserkerAttackStop");
        }
        protected override void ExecuteAttack()
        {
            if(gameObject.activeSelf == true)
            EnemyAnimator.SetTrigger("IsBerserkerAttack");
        }
    }
    
}
