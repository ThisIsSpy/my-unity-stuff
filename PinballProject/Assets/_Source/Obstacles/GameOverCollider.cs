using Pinball;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Obstacles{
    
    public class GameOverCollider : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out PinballLauncher _))
            {
                SceneManager.LoadScene("Game");
            }
        }
    }
    
}
