using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{  
    public interface IFadeService
    {
        public void FadeIn(Image image, float time);

        public void FadeOut(Image image, float time);
    }   
}