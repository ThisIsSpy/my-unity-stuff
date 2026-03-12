using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using xNodeProject.GraphModule;

namespace xNodeProject.UIModule
{
    
    public class BackButton : MonoBehaviour
    {
        [SerializeField] private CardNodeGraph graph;
        private Button button;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(graph.GoBack);
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
    
}
