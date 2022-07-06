using UnityEngine;
using Zenject;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(CannonPresent))]
    public sealed class CannonPresentInitializer : MonoBehaviour, IInitializer
    {
        private CannonPresent _present;
        private ProjectileFactory[] _projectileFactories;

        private void Awake() => _present = GetComponent<CannonPresent>();

        public void Init() => _present.Init(_projectileFactories);

        [Inject]
        public void Init(ProjectileFactory[] projectileFactories) => _projectileFactories = projectileFactories;

    }
}
