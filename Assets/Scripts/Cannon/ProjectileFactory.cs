using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class ProjectileFactory : Factory<ProjectileMovement>
    {
        [SerializeField] private Transform _spawnPoint;

        protected override Vector3 GetNextPoint() => _spawnPoint.position;

        protected override ProjectileMovement GetPrefab() => Prefabs[0];
    }
}
