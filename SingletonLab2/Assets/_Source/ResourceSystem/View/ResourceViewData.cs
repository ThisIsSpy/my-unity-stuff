using System;
using UnityEngine;

namespace ResourceSystem.View
{
    [Serializable]
    public class ResourceViewData
    {
        [field: SerializeField] public ResourceType Type { get; private set; }
        [field: SerializeField] public Sprite ActiveStateIcon { get; private set; }
        [field: SerializeField] public Sprite InactiveStateIcon { get; private set; }
    }
}