using System;
using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class IceCreamHealth : Damagable
    {
        public event Action<Layer> OnRemoved;
        [SerializeField, Tooltip("Have to be from smallest to highest")] private Layer[] _layers;
        private int _layerIndex;

        private void Start() => _layerIndex = _layers.Length;

        protected override void PlayChangeHealthFeedback()
        {
            SetEnableLayer(1, false);
            OnRemoved?.Invoke(_layers[_layerIndex]);
        }

        protected override void PlayHealFeedBack() => AddLayer();
        
        private void AddLayer()
        {
            SetEnableLayer(0, true);
            _layerIndex++;
        }

        private void SetEnableLayer(int decreaseCount, bool isActive)
        {
            _layerIndex -= decreaseCount;
            if (_layerIndex >= 0)
                _layers[_layerIndex].gameObject.SetActive(isActive);
        }
    }
}
