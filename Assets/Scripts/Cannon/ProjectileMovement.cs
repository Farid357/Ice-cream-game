using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class ProjectileMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.5f;
   
        private void Update()
        {
            transform.Translate(Vector3.forward * _speed * Time.deltaTime);
            TryDisable();
        }

        private void TryDisable()
        {
            if (transform.position.z < Grid.MinPositionZ)
                gameObject.SetActive(false);
        }
    }
}
