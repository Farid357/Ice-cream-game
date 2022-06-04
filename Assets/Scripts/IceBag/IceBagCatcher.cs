using IceCream.SaveSystem;
using System;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class IceBagCatcher : MonoBehaviour
    {
        private const int Damage = 1;
        private Camera _camera;
        private readonly IStorage _storage = new BinaryStorage();
        private const string Key = "CatchedBags";
        public int CatchedCount { get; private set; }

        private void Start()
        {
            _camera = Camera.main;
            CatchedCount = _storage.Load<int>(Key);
        }

        private void Update()
        {
            try
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out var hit))
                    {
                        if (hit.transform.gameObject.TryGetComponent(out IceBagHealthView health))
                        {
                            CatchedCount++;
                            health.ApplyDamage(Damage);
                            _storage.Save(Key, CatchedCount);
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
