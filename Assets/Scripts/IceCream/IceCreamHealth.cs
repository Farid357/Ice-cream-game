using System;
using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class IceCreamHealth : Damagable
    {
        [SerializeField, Tooltip("Have to be from highest to smallest")] private GameObject[] _layers;
        private float _layerIndex;

        private void Start() => _layerIndex = _layers.Length;

        protected override void PlayChangeHealthFeedback(float damage)
        {
            _layerIndex -= damage;
            if (_layerIndex == Math.Truncate(_layerIndex))
            {
                _layers[(int)_layerIndex].SetActive(false);
            }
        }
    }
}
