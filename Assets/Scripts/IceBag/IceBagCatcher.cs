using System;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class IceBagCatcher : MonoBehaviour
    {
        private const int Damage = 1;
        private Camera _camera;

        private void Start() => _camera = Camera.main;

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
                            health.ApplyDamage(Damage);
                        }
                    }
                }
            }
            catch (Exception) { }
        }
    }
}
