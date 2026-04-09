using PanicTalkAction.DebaterSystem;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace PanicTalkAction.PanicTalkActionSystem
{
    [TrackBindingType(typeof(PlayerDebater))]
    [TrackClipType(typeof(InTempoClip))]
    public class PlayerTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount) 
            => ScriptPlayable<InTempoClipMixer>.Create(graph, inputCount);
    }
}