﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    
    public class AttackPerformer
    {
        private readonly List<IAttackStrategy> strategyList;
        private IAttackStrategy currentStrategy;

        public List<IAttackStrategy> StrategyList { get { return strategyList; } }

        public AttackPerformer(List<IAttackStrategy> strategyList)
        {
            this.strategyList = strategyList;
        }

        public void ExecuteCurrentStrategy()
        {
            if(currentStrategy != null)
            {
                currentStrategy.ExecuteStrategy();
            }
            else
            {
                Debug.Log("No strategy is set!");
            }
        }
        public void SetCurrentStrategy(int index)
        {
            currentStrategy = strategyList[index];
        }
    }
    
}
