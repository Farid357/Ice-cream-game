using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class IceCreamHealth : Damagable
    {
        [SerializeField, Tooltip("Have to be from highest to smallest")] private GameObject[] _layers;
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

        protected override void PlayChangeHealthFeedback() => SetEnableLayer(1, false);

        private void AddLayer()
        {
            SetEnableLayer(0, true);
            _layerIndex++;
        }

        private void SetEnableLayer(int decreaseCount, bool isActive)
        {
            _layerIndex -= decreaseCount;
            if (_layerIndex >= 0)
                _layers[_layerIndex].SetActive(isActive);
        }
    }
}
