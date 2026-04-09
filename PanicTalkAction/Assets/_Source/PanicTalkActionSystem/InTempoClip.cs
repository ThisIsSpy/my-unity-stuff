using System;
using UnityEngine;
using UnityEngine.Playables;

namespace PanicTalkAction.PanicTalkActionSystem
{
    [Serializable]
    public class InTempoClip : PlayableAsset
    {
        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner) 
            => ScriptPlayable<PlayerPlayableBehaviour>.Create(graph);
    }
}