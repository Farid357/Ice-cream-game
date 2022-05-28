using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(MeshRenderer))]
    public sealed class Plane : MonoBehaviour 
    {
        public Bounds Bounds => _meshRenderer.bounds;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
        }
    }
}
