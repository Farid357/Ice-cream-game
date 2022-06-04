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
        private float _healthMax;

        private void Start()
        {
            _layerIndex = _layers.Length;
            _healthMax = Health;
        }

        public void Heal(float health)
        {
            if (Health + health <= _healthMax)
            {
                Health += health;
                OnChanged.Invoke(Health);
                AddLayer();
            }
        }

        protected override void PlayChangeHealthFeedback()
        {
            SetEnableLayer(1, false);
            OnRemoved?.Invoke(_layers[_layerIndex]);
        }

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
