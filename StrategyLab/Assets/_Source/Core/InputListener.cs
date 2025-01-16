using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AttackSystem;

namespace Core
{
    
    public class InputListener : MonoBehaviour
    {
        [SerializeField] private KeyCode attackKey;
        private AttackPerformer performer;

        public void Construct(AttackPerformer performer)
        {
            this.performer = performer;
        }

        private void Update()
        {
            ListenForAttackInput();
        }
        private void ListenForAttackInput()
        {
            if(Input.GetKeyDown(attackKey))
            {
                performer.ExecuteCurrentStrategy();
            }
        }
    }
    
}
