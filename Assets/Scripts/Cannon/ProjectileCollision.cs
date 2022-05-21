using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(ProjectileMovement), typeof(SphereCollider))]
    public sealed class ProjectileCollision : MonoBehaviour
    {
        private const int Damage = 1;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IceCreamHealth damagable))
            {
                damagable.ApplyDamage(Damage);
                gameObject.SetActive(false);
            }
        }
    }
}
