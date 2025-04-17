using BulletSystem;
using Player;
using Services;
using UnityEngine;
using Zenject;

namespace Core 
{
    public class MainInstaller : MonoInstaller
    {
        [SerializeField] private Transform bulletSpawnPos;
        [SerializeField] private AudioSource soundPlayerSource;
        [SerializeField] private AudioClip[] bulletSounds;
        [SerializeField] private InputListener inputListener;
        [SerializeField] private PlayerShooter playerShooter;
        [SerializeField] private Bullet bulletPrefab;
        public override void InstallBindings()
        {
            Container.Bind<Transform>().FromInstance(bulletSpawnPos).AsSingle();
            Container.Bind<AudioSource>().FromInstance(soundPlayerSource).AsSingle();
            Container.Bind<AudioClip[]>().FromInstance(bulletSounds).AsSingle();
            Container.Bind<InputListener>().FromInstance(inputListener).AsSingle();
            Container.Bind<PlayerShooter>().FromInstance(playerShooter).AsSingle();

            Container.Bind<BulletPool>().AsSingle();
            Container.Bind<SoundPlayer>().AsSingle();

            Container.Bind<BulletSpawner>().AsSingle();
            Container.BindFactory<Bullet, Bullet.Factory>().FromComponentInNewPrefab(bulletPrefab);
        }
    }
}