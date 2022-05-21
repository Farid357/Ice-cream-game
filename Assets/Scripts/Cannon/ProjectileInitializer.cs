using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(ProjectileMovement), typeof(ProjectileCollision), typeof(MeshRenderer))]
    public sealed class ProjectileInitializer : MonoBehaviour, IInitializer
    {
        private MeshRenderer _renderer;

        private void OnEnable() => _renderer = GetComponent<MeshRenderer>();

        public void Init()
        {
            _renderer.material.color = Random.ColorHSV(hueMin: 0, hueMax: 1, saturationMin: 0, saturationMax: 1,  alphaMin: 1, alphaMax: 1, valueMin: 0, valueMax: 1);
        }
    }
}
