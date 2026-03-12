using System;
using UnityEngine;
using XNode;
using xNodeProject.GraphModule;

namespace xNodeProject.NodeModule
{
    public class CardNode : Node
    {
        [Input] public CardNode previousNode;
        [Input] public string situationDescription, firstChoice, secondChoice;
        [Input] public bool canGoBack;
        [Output] public Empty firstChoiceNextNode;
        [Output] public Empty secondChoiceNextNode;

        public bool CanMoveNext(bool isSecondChoice)
        {
            CardNodeGraph fmGraph = graph as CardNodeGraph;

            if (fmGraph.current != this)
            {
                Debug.LogWarning("Node isn't active");
                return false;
            }

            NodePort exitPort = GetOutputPort(isSecondChoice ? nameof(secondChoiceNextNode) : nameof(firstChoiceNextNode));
            //if (!isSecondChoice) exitPort = GetOutputPort(nameof(firstChoiceNextNode));
            //else exitPort = GetOutputPort(nameof(secondChoiceNextNode));

            if (!exitPort.IsConnected)
            {
                Debug.LogWarning("Node isn't connected");
                return false;
            }

            CardNode nextNode = exitPort.Connection.node as CardNode;
            nextNode.OnEnter();

            return true;
        }

        public bool CanMoveBackwards()
        {
            if(!canGoBack) return false;
            CardNodeGraph fmGraph = graph as CardNodeGraph;

            if (fmGraph.current != this)
            {
                Debug.LogWarning("Node isn't active");
                return false;
            }

            NodePort exitPort = GetInputPort(nameof(previousNode));

            if (!exitPort.IsConnected)
            {
                Debug.LogWarning("Node isn't connected");
                return false;
            }

            CardNode nextNode = exitPort.Connection.node as CardNode;
            nextNode.OnEnter();

            return true;
        }

        public void OnEnter()
        {
            CardNodeGraph fmGraph = graph as CardNodeGraph;
            fmGraph.current = this;
        }
    }

    [Serializable] public class Empty { }
}