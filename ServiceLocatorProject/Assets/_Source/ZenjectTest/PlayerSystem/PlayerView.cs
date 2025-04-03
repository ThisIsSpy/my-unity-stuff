using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ZenjectTest.PlayerSystem
{
    
    public class PlayerView : MonoBehaviour
    {
        private PlayerModel model;
        [Inject]
        public void Construct(int id, PlayerModel playerModel)
        {
            Debug.Log($"done {id}");
            model = playerModel;
        }
    }
    
}
