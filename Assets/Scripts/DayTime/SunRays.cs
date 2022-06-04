using UnityEngine;
using System.Collections;
using System;

namespace IceCream.GameLogic
{
    public sealed class SunRays : MonoBehaviour
    {
        public event Action OnHeated;
        public event Action<bool> OnChanged;
        [SerializeField] private IceCreamHealth _health;
        [SerializeField] private float _takeHealthCount = 0.1f;
        [SerializeField] private float _delay = 3f;
        private bool _canFry = true;

        public void Start() => StartCoroutine(Fry());

        private IEnumerator Fry()
        {
            var wait = new WaitForSeconds(_delay);
            while (true)
            {
                yield return wait;
                if (_canFry)
                {
                    _health.ApplyDamage(_takeHealthCount);
                    OnHeated.Invoke();
                }
            }
        }

        public void StopFryForSeconds(int seconds) => StartCoroutine(StopFry(seconds));

        private IEnumerator StopFry(int seconds)
        {
            _canFry = false;
            OnChanged?.Invoke(true);
            yield return new WaitForSeconds(seconds);
            _canFry = true;
            OnChanged?.Invoke(false);
        }
    }
}