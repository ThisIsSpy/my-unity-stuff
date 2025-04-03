using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    [CreateAssetMenu(fileName = "SoundListSO", menuName = "SO/New Sound List SO", order = 0)]
    public class SoundListSO : ScriptableObject
    {
        [field: SerializeField] public AudioClip OpenPanelSound { get; private set; }
        [field: SerializeField] public AudioClip ClosePanelSound { get; private set; }
    }
    
}
