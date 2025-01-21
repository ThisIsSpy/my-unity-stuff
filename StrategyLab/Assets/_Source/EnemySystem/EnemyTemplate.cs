using System.Collections;
using System.Collections.Generic;
using AttackSystem;
using UnityEngine;

namespace EnemySystem
{
    public abstract class EnemyTemplate : MonoBehaviour
    {
        protected Animator enemyAnimator;

        public Animator EnemyAnimator { get { return enemyAnimator; }  set { enemyAnimator = value; } }

        protected abstract void ExecuteAttack();
        public virtual void EnemyMethod()
        {
            ExecuteAttack();
        }
    }
    
}
