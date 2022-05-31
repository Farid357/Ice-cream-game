using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PresentMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.5f;
        private Vector3 _direction = Vector3.left;
        private Rigidbody _rigidbody;

        private void Start() => _rigidbody = GetComponent<Rigidbody>();

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _direction * _speed * Time.fixedDeltaTime);
        }
    }
}
