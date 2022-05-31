using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(Camera))]
    public sealed class CameraColor : MonoBehaviour
    {
        private Color _startColor;
        private Camera _camera;

        private void Awake() => _camera = GetComponent<Camera>();

        public void SetNew(Color color)
        {
            _startColor = _camera.backgroundColor;
            _camera.backgroundColor = color;
        }

        public void Clear()
        {
            if (_startColor == null) throw new System.InvalidOperationException(nameof(Clear));
            _camera.backgroundColor = _startColor;
        }
    }
}
