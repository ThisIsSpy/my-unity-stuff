using Panels;
using Panels.Statemachine;
using Panels.UIStates;
using Score;
using Services;
using UnityEngine;
using Zenject;
using ZenjectTest.PlayerSystem;

namespace Core 
{
    
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private MainPanelView mainPanelView;
        [SerializeField] private SecondPanelView secondPanelView;
        [SerializeField] private ScoreCounter scoreCounter;
        [SerializeField] private SoundListSO soundList;
        [SerializeField] private AudioSource audioSource;
        public override void InstallBindings()
        {
            //Container.Bind<int>().FromInstance(10).AsSingle();
            //Container.Bind<PlayerView>().FromInstance(playerView).AsSingle();
            //Container.Bind<PlayerModel>().AsSingle();

            Container.Bind<MainPanelView>().FromInstance(mainPanelView).AsSingle();
            Container.Bind<SecondPanelView>().FromInstance(secondPanelView).AsSingle();
            Container.Bind<ScoreCounter>().FromInstance(scoreCounter).AsSingle();
            Container.Bind<SoundListSO>().FromInstance(soundList).AsSingle();
            Container.Bind<AudioSource>().FromInstance(audioSource).AsSingle();

            Container.Bind<IFadeService>().To<FadeService>().AsSingle();
            Container.Bind<ISoundPlayer>().To<SoundPlayer>().AsSingle();
            //Container.Bind<ISaver>().To<JSONSaver>().AsSingle();
            Container.Bind<ISaver>().To<PlayerPrefsSaver>().AsSingle();

            Container.Bind<MainPanelController>().AsSingle();
            Container.Bind<SecondPanelController>().AsSingle();
            Container.Bind<IStatemachine>().To<UISwitcher<UIController>>().AsSingle().NonLazy();
        }
    }
}