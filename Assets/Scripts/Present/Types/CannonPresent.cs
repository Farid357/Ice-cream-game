using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class CannonPresent : Present
    {
        [SerializeField] private float _delay = 5f;
        private List<ProjectileFactory> _projectileFactories;

        public void Init(ProjectileFactory[] projectileFactories)
        {
            _projectileFactories = projectileFactories.ToList() ?? throw new System.ArgumentNullException(nameof(projectileFactories));
        }

        protected override void PlayApplyFeedBack() => RestartFactories(_projectileFactories);

        private async void RestartFactories(List<ProjectileFactory> factories)
        {
            factories.ForEach(factory => factory.StopSpawn());
            FindObjectsOfType<ProjectileCollision>().ToList().ForEach(projectile => projectile.gameObject.SetActive(false));
            await Task.Delay(TimeSpan.FromSeconds(_delay));
            factories.ForEach(factory => factory.StartSpawn());
        }
    }
}
