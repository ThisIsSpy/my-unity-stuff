using ResourceSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ResourceSystem.Data
{
    [Serializable]
    public class ResourceData
    {
        [field: SerializeField] public ResourceType Type { get; private set; }
        [field: SerializeField] public float ActiveTime { get; private set; }
        [field: SerializeField] public float InactiveTime { get; private set; }
    }
}