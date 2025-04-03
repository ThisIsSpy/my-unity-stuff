using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Panels.UIStates
{
    public class SecondPanelController : UIController
    {
        public SecondPanelView SecondPanelView { get; private set; }
        private readonly SoundListSO soundListSO;
        private readonly IFadeService fadeService;
        private readonly ISoundPlayer soundPlayer;

        public SecondPanelController(SecondPanelView secondPanelView, SoundListSO soundListSO, IFadeService fadeService, ISoundPlayer soundPlayer)
        {
            SecondPanelView = secondPanelView;
            this.soundListSO = soundListSO;
            this.fadeService = fadeService;
            this.soundPlayer = soundPlayer;
        }

        public override void Enter()
        {
            SecondPanelView.gameObject.SetActive(true);
            fadeService.FadeIn(SecondPanelView.GetComponent<Image>(), 2f);
            soundPlayer.PlayOpenSound(soundListSO.OpenPanelSound);

        }

        public override void Exit()
        {
            SecondPanelView.StartCoroutine(ExitCoroutine());
        }

        private IEnumerator ExitCoroutine()
        {
            fadeService.FadeOut(SecondPanelView.GetComponent<Image>(), 2f);
            soundPlayer.PlayCloseSound(soundListSO.ClosePanelSound);
            yield return new WaitForSeconds(2f);
            SecondPanelView.gameObject.SetActive(false);
        }
    }
}