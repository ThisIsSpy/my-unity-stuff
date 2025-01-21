using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AttackSystem
{
    
    public class AttackStrategySetter : MonoBehaviour
    {
        private int index;
        private AttackPerformer performer;
        private Button button;

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

        public void Construct(int index, AttackPerformer performer, Button button)
        {
            this.performer = performer;
            this.button = button;
            Index = index;
            this.button.onClick.AddListener(OnButtonPress);
        }
        private void OnDestroy()
        {
            button.onClick.RemoveListener(OnButtonPress);
        }
        public void OnButtonPress()
        {
            performer.SetCurrentStrategy(index);
        }
    }
    
}
