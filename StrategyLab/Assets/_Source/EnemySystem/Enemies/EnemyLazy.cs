using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem.Enemies{
    
    public class EnemyLazy : EnemyTemplate
    {
        public void Construct(Animator enemyAnimator)
        {
            EnemyAnimator = enemyAnimator;
        }
        private void OnEnable()
        {
            EnemyMethod();
        }
        protected override void ExecuteAttack()
        {
            if (gameObject.activeSelf == true)
                EnemyAnimator.SetTrigger("IsLazyAttack");
        }
    }
    
}
