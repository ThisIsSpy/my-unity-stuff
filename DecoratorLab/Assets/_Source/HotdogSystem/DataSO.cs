using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HotdogSystem
{
    public abstract class DataSO : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Cost { get; private set; }
        [field: SerializeField] public int Mass { get; private set; }
    }
    
}
