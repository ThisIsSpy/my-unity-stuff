using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.UIStates
{
    public class SecondPanelController : UIController
    {
        private readonly SecondPanelView secondPanelView;
        private readonly AudioClip openPanelClip;
        private readonly AudioClip closePanelClip;
        private readonly ServiceLocator serviceLocator;

        public SecondPanelController(SecondPanelView secondPanelView, AudioClip openPanelClip, AudioClip closePanelClip, ServiceLocator serviceLocator)
        {
            this.secondPanelView = secondPanelView;
            this.openPanelClip = openPanelClip;
            this.closePanelClip = closePanelClip;
            this.serviceLocator = serviceLocator;
        }

        public override void Enter()
        {
            secondPanelView.gameObject.SetActive(true);
            if (!serviceLocator.GetService(out FadeService service)) Debug.Log("couldn't locate fade service");
            else service.FadeIn(secondPanelView.GetComponent<Image>(), 2f);
            if (!serviceLocator.GetService(out SoundPlayer service2)) Debug.Log("couldn't locate sound player");
            else service2.PlayOpenSound(openPanelClip);

        }

        public override void Exit()
        {
            secondPanelView.StartCoroutine(ExitCoroutine());
        }

        private IEnumerator ExitCoroutine()
        {
            if (!serviceLocator.GetService(out FadeService service)) Debug.Log("couldn't locate fade service");
            else service.FadeOut(secondPanelView.GetComponent<Image>(), 2f);
            if (!serviceLocator.GetService(out SoundPlayer service2)) Debug.Log("couldn't locate sound player");
            else service2.PlayCloseSound(closePanelClip);
            yield return new WaitForSeconds(2f);
            secondPanelView.gameObject.SetActive(false);
        }
    }
}