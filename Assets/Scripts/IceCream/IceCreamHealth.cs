using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class IceCreamHealth : Damagable
    {
        [SerializeField, Tooltip("Have to be from highest to smallest")] private GameObject[] _layers;
        private int _layerIndex;

        private void Start() => _layerIndex = _layers.Length;

        protected override void PlayChangeHealthFeedback()
        {
            _layerIndex -= 1;
            _layers[_layerIndex].SetActive(false);
        }
    }
}
