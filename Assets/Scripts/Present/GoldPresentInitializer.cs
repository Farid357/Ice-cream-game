using UnityEngine;
using Zenject;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(GoldPresent))]
    public sealed class GoldPresentInitializer : MonoBehaviour, IInitializer
    {
        [SerializeField] private int _maxGoldCount = 6;
        [SerializeField] private int _minGoldCount = 2;

        private GoldPresentsCollector _collector;
        private GoldPresent _goldPresent;

        private void Awake() => _goldPresent = GetComponent<GoldPresent>();

        [Inject]
        public void Init(GoldPresentsCollector collector) => _collector = collector;

        public void Init()
        {
            if (_goldPresent == null) throw new System.ArgumentNullException(nameof(_goldPresent));
            var goldCount = Random.Range(_minGoldCount, _maxGoldCount);
            _goldPresent.Init(_collector, goldCount);
        }
    }
}
