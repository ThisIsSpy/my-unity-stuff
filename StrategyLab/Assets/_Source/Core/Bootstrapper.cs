using AttackSystem;
using AttackSystem.AttackStrategies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private GameObject robot;
        [SerializeField] private List<AttackStrategySetter> setterList;
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
            inputListener.Construct(attackPerformer);
        }
    }
    
}
