using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class PresentCollision : MonoBehaviour
    {
        private Present _present;

        private void Start() => _present = GetComponent<Present>();

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out ProjectileMovement projectile))
            {
                projectile.gameObject.SetActive(false);
            }
            if (collision.gameObject.TryGetComponent(out IceCreamHealth iceCream))
            {
                _present.Apply();
            }
        }
    }
}
