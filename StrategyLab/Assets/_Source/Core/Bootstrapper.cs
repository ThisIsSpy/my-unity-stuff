using AttackSystem;
using AttackSystem.AttackStrategies;
using EnemySystem;
using EnemySystem.Enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject robot;
        [SerializeField] private List<AttackStrategySetter> setterList;
        [SerializeField] private List<EnemySetter> enemySetterList;
        [SerializeField] private List<EnemyTemplate> enemyList;
        [SerializeField] private InputListener inputListener;
        private List<IAttackStrategy> attackStrategies;
        private ArmsAttack armsAttackStrategy;
        private BombAttack bombAttackStrategy;
        private LaserAttack laserAttackStrategy;
        private AttackPerformer attackPerformer;

        private void Start()
        {
            Animator robotAnimator = robot.GetComponent<Animator>();

            armsAttackStrategy = new(robotAnimator);
            bombAttackStrategy = new(robotAnimator);
            laserAttackStrategy = new(robotAnimator);
            attackStrategies = new() 
            { 
                armsAttackStrategy,
                bombAttackStrategy,
                laserAttackStrategy
            };
            attackPerformer = new(attackStrategies);
            for(int i = 0; i < setterList.Count; i++)
            {
                setterList[i].Construct(i, attackPerformer);
            }
            foreach(EnemyTemplate enemy in enemyList)
            {
                if(enemy.GetType() == typeof(EnemyCopier))
                {
                    EnemyCopier enemyCopier = (EnemyCopier)enemy;
                    enemyCopier.Construct(enemy.gameObject.GetComponent<Animator>(), attackPerformer);
                }
                else if(enemy.GetType() == typeof(EnemyBerserker))
                {
                    EnemyBerserker enemyBerserker = (EnemyBerserker)enemy;
                    enemyBerserker.Construct(enemy.gameObject.GetComponent<Animator>());
                }
                else if (enemy.GetType() == typeof(EnemyLazy))
                {
                    EnemyLazy enemyLazy = (EnemyLazy)enemy;
                    enemyLazy.Construct(enemy.gameObject.GetComponent<Animator>());
                }
            }
            for(int i = 0; i < enemySetterList.Count; i++)
            {
                enemySetterList[i].Construct(i, enemyList);
            }
            inputListener.Construct(attackPerformer);
        }
    }
    
}
