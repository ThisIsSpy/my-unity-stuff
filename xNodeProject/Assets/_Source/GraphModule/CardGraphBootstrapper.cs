using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace xNodeProject.GraphModule
{
    
    public class CardGraphBootstrapper : MonoBehaviour
    {
        [SerializeField] private CardNodeGraph graph;

        private void Start()
        {
            graph.StartGraph();
        }
    }
    
}
