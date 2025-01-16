using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AttackSystem
{
    
    public class AttackStrategySetter : MonoBehaviour
    {
        private int index;
        private AttackPerformer performer;

        public int Index
        {
            get { return index; }
            set
            {
                if(value < 0)
                {
                    index = 0;
                }
                else if(value >= performer.StrategyList.Count)
                {
                    index = performer.StrategyList.Count - 1;
                }
                else
                {
                    index = value;
                }
            }
        }

        public void Construct(int index, AttackPerformer performer)
        {
            this.performer = performer;
            Index = index;
        }

        public void OnButtonPress()
        {
            performer.SetCurrentStrategy(index);
        }
    }
    
}
