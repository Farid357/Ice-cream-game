using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(ProjectileMovement), typeof(SphereCollider))]
    public sealed class ProjectileCollision : MonoBehaviour
    {
        [SerializeField] private float _damage = 0.25f;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IceCreamHealth damagable))
            {
                damagable.ApplyDamage(_damage);
                gameObject.SetActive(false);
            }
        }
    }
}
