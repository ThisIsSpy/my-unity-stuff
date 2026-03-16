using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using XNode;
using xNodeProject.NodeModule;

namespace xNodeProject.GraphModule
{
    [CreateAssetMenu]
    public class CardNodeGraph : NodeGraph 
    {
        public CardNode current;
        public event Action<CardNode> OnCardChange;

        public void StartGraph()
        {
            //current = nodes[0] as CardNode;
            current = GetFirstNode() as CardNode;
            OnCardChange?.Invoke(current);
        }

        public void Continue(bool isSecondChoice)
        {
            if(current.CanMoveNext(isSecondChoice)) OnCardChange?.Invoke(current);
        }

        public void GoBack()
        {
            if(current.CanMoveBackwards()) OnCardChange?.Invoke(current);
        }

        public Node GetFirstNode()
        {
            IEnumerable sortedNodes = nodes.OrderBy(n => n.position);
            foreach(Node node in sortedNodes)
            {
                if(node is CardNode cardNode && (cardNode.firstChoiceNextNode != null && cardNode.secondChoiceNextNode != null)) return node;
            }
            return null;
        }
    }
}