using UnityEngine;
using System.Collections;

namespace IceCream.GameLogic
{
    public sealed class SunRays : MonoBehaviour
    {
        [SerializeField] private IceCreamHealth _health;
        [SerializeField] private CameraColor _camera;
        [SerializeField] private IceBagFactory _factory;
        [SerializeField] private ParticleSystem _snowParticle;
        [SerializeField] private float _takeHealthCount = 0.1f;
        [SerializeField] private float _delay = 3f;
        private bool _canFry = true;

        private void Start() => StartCoroutine(Fry());

        private IEnumerator Fry()
        {
            var wait = new WaitForSeconds(_delay);
            while (true)
            {
                yield return wait;
                if (_canFry)
                {
                    _health.ApplyDamage(_takeHealthCount);
                }
            }
        }

        public void StopFryForSeconds(int seconds) => StartCoroutine(StopFry(seconds));

        private IEnumerator StopFry(int seconds)
        {
            _canFry = false;
            _camera.SetNew(Color.black);
            SetActiveSnow(false);
            yield return new WaitForSeconds(seconds);
            _canFry = true;
            _camera.Clear();
            SetActiveSnow(true);
            _factory.StartSpawn();
        }

        private void SetActiveSnow(bool isActive)
        {
            _factory.gameObject.SetActive(isActive);
            _snowParticle.gameObject.SetActive(isActive);
        }
    }
}
