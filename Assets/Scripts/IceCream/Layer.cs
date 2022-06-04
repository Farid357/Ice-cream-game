using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class Layer : MonoBehaviour
    {
        public Color Color => _meshRenderer.material.color;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void SetAlpha(float a)
        {
            Color color = _meshRenderer.material.color;
            _meshRenderer.material.color = new Color(color.r, color.g, color.b, a);
        }
    }
}
