using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Services
{
    
    public interface ISoundPlayer
    {
        public void PlayOpenSound(AudioClip sound);

        public void PlayCloseSound(AudioClip sound);
    }
    
}