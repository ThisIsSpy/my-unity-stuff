using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Services 
{

    public class FadeService : IFadeService
    {
        public void FadeIn(Image image, float time)
        {
            image.DOFade(1, time);
        }

        public void FadeOut(Image image, float time)
        {
            image.DOFade(0, time);
        }
    }

}
