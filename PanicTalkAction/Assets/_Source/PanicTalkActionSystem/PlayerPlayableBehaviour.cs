using PanicTalkAction.DebaterSystem;
using UnityEngine;
using UnityEngine.Playables;

namespace PanicTalkAction.PanicTalkActionSystem
{
    public class PlayerPlayableBehaviour : PlayableBehaviour
    {
        public bool InTempo;
        private PlayerDebater playerDebater;

        public override void OnGraphStart(Playable playable)
        {
            if (Application.isPlaying)
            {
                playerDebater = Object.FindFirstObjectByType<PlayerDebater>();
            }
        }

        public override void OnBehaviourPlay(Playable playable, FrameData info)
        {
            if (Application.isPlaying)
            {
                playerDebater.IsBeat.Value = true;
            }
        }

        public override void OnBehaviourPause(Playable playable, FrameData info)
        {
            if (Application.isPlaying)
            {
                var duration = playable.GetDuration();
                var time = playable.GetTime();
                var count = time + info.deltaTime;

                if ((info.effectivePlayState == PlayState.Paused && count > duration) || Mathf.Approximately((float)time, (float)duration))
                {
                    playerDebater.IsBeat.Value = false;
                }
                return;
            }
        }
    }
}