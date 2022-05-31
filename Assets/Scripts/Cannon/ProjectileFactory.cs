using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class ProjectileFactory : Factory<ProjectileMovement>
    {
        [SerializeField] private Transform _spawnPoint;

        public override Vector3 GetNextPoint() => _spawnPoint.position;

        public override ProjectileMovement GetPrefab() => Prefabs[0];
    }
}
