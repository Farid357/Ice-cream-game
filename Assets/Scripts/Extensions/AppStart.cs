using IceCream.GameLogic;
using IceCream.Tools;
using UnityEngine;
using Zenject;

namespace IceCream.App
{
    public sealed class AppStart : MonoInstaller
    {
        [SerializeField] private SunRays _sunRays;
        [SerializeField] private IceCreamHealth _iceCream;
        [SerializeField] private AudioSource _presentAudio;

        public override void InstallBindings()
        {
            Container.Bind<GoldPresentsCollector>().FromNew().AsSingle().NonLazy();
            Container.Bind<ObjectsPool<IceBagMovement>>().FromNew().AsSingle();
            Container.Bind<ObjectsPool<ProjectileMovement>>().FromNew().AsSingle();
            Container.Bind<ObjectsPool<Present>>().FromNew().AsSingle();
            Container.BindInstance(_iceCream).AsSingle();
            Container.BindInstance(_presentAudio).AsSingle();
            Container.BindInstance(_sunRays).AsSingle();
        }

    }
}