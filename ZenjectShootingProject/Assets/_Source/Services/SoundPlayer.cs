using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    public class SoundPlayer
    {
        private readonly AudioSource audioSource;

        public SoundPlayer(AudioSource audioSource)
        {
            this.audioSource = audioSource;
        }
        
        public void PlaySound(AudioClip sound)
        {
            audioSource.PlayOneShot(sound);
        }
    }
}