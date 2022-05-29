using IceCream.GameLogic;
using IceCream.Tools;
using UnityEngine;
using Zenject;

namespace IceCream.App
{
    public sealed class AppStart : MonoInstaller
    {
        [SerializeField] private IceCreamHealth _iceCream;

        public override void InstallBindings()
        {
            Container.Bind<ObjectsPool<IceBagMovement>>().FromNew().AsSingle();
            Container.Bind<ObjectsPool<ProjectileMovement>>().FromNew().AsSingle();
            Container.BindInstance(_iceCream).AsSingle();
        }
    }
}