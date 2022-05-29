using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace IceCream.GameLogic
{
    public class SunRays : MonoBehaviour
    {
        [SerializeField] private float _delay = 0.4f;
        [SerializeField] private IceCreamHealth _health;
        [SerializeField] private float _takeHealthCount = 0.1f;

        private void Start() => Fry();

        private async void Fry()
        {
            while (_health)
            {
                await Task.Delay(TimeSpan.FromSeconds(_delay));
                _health.ApplyDamage(_takeHealthCount);
            }
        }
    }
}
