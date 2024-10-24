using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

namespace Core
{
    public class InputListener : MonoBehaviour
    {
        public SceneReseter Reseter;
        private void Update()
        {
            ListenForGameOverInput();
        }

        private void ListenForGameOverInput()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Reseter.ResetScene();   
            }
        }
    }
}