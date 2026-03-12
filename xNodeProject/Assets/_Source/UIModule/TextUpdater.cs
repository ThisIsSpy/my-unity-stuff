using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using xNodeProject.GraphModule;
using xNodeProject.NodeModule;

namespace xNodeProject.UIModule
{
    public class TextUpdater : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI situationDescription, firstChoiceText, secondChoiceText;
        [SerializeField] private CardNodeGraph cardNodeGraph;

        private void Start()
        {
            cardNodeGraph.OnCardChange += UpdateText;
            UpdateText(cardNodeGraph.nodes[0] as CardNode);
        }

        private void OnDestroy()
        {
            cardNodeGraph.OnCardChange -= UpdateText;
        }

        public void UpdateText(CardNode node)
        {
            situationDescription.text = node.situationDescription;
            firstChoiceText.text = node.firstChoice;
            secondChoiceText.text = node.secondChoice;
        }
    }
}