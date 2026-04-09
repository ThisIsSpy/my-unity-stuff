using PanicTalkAction.DebaterSystem;
using UnityEngine;
using UnityEngine.Playables;

namespace PanicTalkAction.PanicTalkActionSystem
{
    public class InTempoClipMixer : PlayableBehaviour
    {
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            var player = (PlayerDebater)playerData;
            bool inTempo = false;
            if (player == null) return;

            int inputCount = playable.GetInputCount();
            for(int i = 0; i < inputCount; i++)
            {
                float weight = playable.GetInputWeight(i);
                if(weight > 0) inTempo = true;
            }

            player.InTempo = inTempo;
        }
    }
}