using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services{

    public class SoundPlayer : ISoundPlayer
    {
        private readonly AudioSource audioSource;

        public SoundPlayer(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }

        public void PlayCloseSound(AudioClip sound)
        {
            audioSource.PlayOneShot(sound);
        }

        public void PlayOpenSound(AudioClip sound)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}