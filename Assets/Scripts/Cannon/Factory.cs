using UnityEngine;
using IceCream.Tools;
using System.Collections;
using Zenject;

namespace IceCream.GameLogic
{
    public abstract class Factory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField, Tooltip("Can be null")] private Transform _parent;
        [SerializeField] private T[] _prefabs;
        [SerializeField] private int _startCount = 3;
        [SerializeField] private float _spawnDelay = 0.5f;

        private ObjectsPool<T> _pool;
        private bool _canSpawning = true;

        protected T[] Prefabs => _prefabs;

        [Inject]
        public void Init(ObjectsPool<T> pool) => _pool = pool;

        private void Awake()
        {
            foreach (var prefab in _prefabs)
            {
                _pool.Add(_startCount, prefab, _parent);
            }
            StartCoroutine(Spawn());
        }

        public void StartSpawn() => _canSpawning = true;

        public void StopSpawn() => _canSpawning = false;

        private IEnumerator Spawn()
        {
            var wait = new WaitForSeconds(_spawnDelay);
            while (_canSpawning)
            {
                yield return wait;
                var prefab = GetPrefab();
                var spawnObject = _pool.Get(prefab);
                spawnObject.gameObject.SetActive(true);
                spawnObject.transform.position = GetNextPoint();
                if (spawnObject.TryGetComponent(out IInitializer initializer))
                {
                    initializer.Init();
                }
                else
                {
                    throw new System.InvalidOperationException("Spawn object not implemmnt interface IInitaoilizer!");
                }
            }
        }

        protected abstract T GetPrefab();

        protected abstract Vector3 GetNextPoint();

    }
}
