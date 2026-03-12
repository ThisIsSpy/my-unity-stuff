using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using xNodeProject.GraphModule;

namespace xNodeProject.UIModule
{
    
    public class CardSwitcherButton : MonoBehaviour
    {
        [SerializeField] private CardNodeGraph cardNodeGraph;
        [SerializeField] private bool isSecondChoice;
        private Button button;

        private void Start()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => cardNodeGraph.Continue(isSecondChoice));
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
