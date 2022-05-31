using UnityEngine;
using Zenject;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(NightPresent))]
    public sealed class NightPresentInitializer : MonoBehaviour, IInitializer
    {
        [SerializeField] private int _maxNightSeconds = 10;
        [SerializeField] private int _minNightSeconds = 5;
        private NightPresent _present;
        private SunRays _sunRays;

        private void Awake() => _present = GetComponent<NightPresent>();

        public void Init()
        {
            var randomSeconds = UnityEngine.Random.Range(_minNightSeconds, _maxNightSeconds);
            _present.Init(_sunRays, randomSeconds);
        }

        [Inject]
        public void Initialize(SunRays sunRays) => _sunRays = sunRays;
    }
}
