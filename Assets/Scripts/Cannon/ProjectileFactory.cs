using UnityEngine;
using IceCream.Tools;
using System.Collections;

namespace IceCream.GameLogic
{
    public sealed class ProjectileFactory : MonoBehaviour
    {
        [SerializeField] private ProjectileMovement _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private int _startCount = 3;
        [SerializeField] private float _spawnDelay = 0.5f;
        private ObjectsPool<ProjectileMovement> _pool = new();
   
        private void Start()
        {
            _pool.Add(_startCount, _prefab, _spawnPoint);
            StartCoroutine(Spawn());
        }

        private IEnumerator Spawn()
        {
            var wait = new WaitForSeconds(_spawnDelay);
            while (true)
            {
                yield return wait;
                var projectile = _pool.Get(_prefab);
                projectile.gameObject.SetActive(true);
                projectile.transform.position = _spawnPoint.position;
            }
        }
    }

}
