using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EnemySystem{
    
    public class EnemySetter : MonoBehaviour
    {
        private int index;
        private List<EnemyTemplate> enemyList;
        private Button button;

        public int Index { get { return index; }
            private set 
            { 
                index = Mathf.Clamp(value, 0, enemyList.Count-1);
            }
        }

        public void Construct(int index, List<EnemyTemplate> enemyList, Button button)
        {
            this.enemyList = enemyList;
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
            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].gameObject.SetActive(i == index);
            }
        }
    }
    
}
