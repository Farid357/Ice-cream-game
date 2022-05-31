using UnityEngine;
using Zenject;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(GoldPresent))]
    public sealed class GoldPresentInitializer : MonoBehaviour, IInitializer
    {
        private GoldPresentsCollector _collector;
        private GoldPresent _goldPresent;

        private void Awake() => _goldPresent = GetComponent<GoldPresent>();

        [Inject]
        public void Init(GoldPresentsCollector collector) => _collector = collector;

        public void Init()
        {
            if (_goldPresent == null) throw new System.ArgumentNullException(nameof(_goldPresent));
            _goldPresent.Init(_collector);
        }
    }
}
