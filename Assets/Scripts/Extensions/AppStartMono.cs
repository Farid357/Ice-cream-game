using UnityEngine;
using IceCream.GameLogic;
using Zenject;

namespace IceCream.App
{
    public sealed class AppStartMono : MonoBehaviour
    {
        [SerializeField] private GoldPresentsCollectorView _view;
        private GoldPresentsCollectorController _controller;
        private GoldPresentsCollector _collector;

        private void Awake()
        {
            _controller = new(_view, _collector);
            _controller.Enable();
        }

        [Inject]
        public void Init(GoldPresentsCollector collector) => _collector = collector;
    }
}