using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class SceneReseter
    {
        public void ResetScene()
        {
            string name = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(name);
        }
    }
}