using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class IceCreamMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.5f;
        [SerializeField] private Plane _plane;

        public void Move(Vector2 direction)
        {
            const float offset = 1.3f;
            transform.Translate(direction * _speed * Time.deltaTime);
            var positionX = Mathf.Clamp(transform.position.x, _plane.Bounds.min.x + offset, _plane.Bounds.max.x - offset);
            transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        }
    }
}
