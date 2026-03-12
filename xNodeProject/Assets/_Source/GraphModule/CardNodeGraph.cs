using System;
using System.Collections;
using System.Collections.Generic;
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

        public void Awake()
        {
            current = nodes[0] as CardNode;
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
    }
}