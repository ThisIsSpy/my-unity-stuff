using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemySystem{
    
    public class EnemySetter : MonoBehaviour
    {
        private int index;
        private List<EnemyTemplate> enemyList;

        public int Index { get { return index; }
            private set 
            { 
                index = Mathf.Clamp(value, 0, enemyList.Count-1);
            }
        }

        public void Construct(int index, List<EnemyTemplate> enemyList)
        {
            this.enemyList = enemyList;
            Index = index;
        }

        public void OnButtonPress()
        {
            for (int i = 0; i < enemyList.Count; i++)
            {
                if(i== index)
                {
                    enemyList[i].gameObject.SetActive(true);
                }
                else
                {
                    enemyList[i].gameObject.SetActive(false);
                }
            }
        }
    }
    
}
