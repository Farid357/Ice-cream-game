using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class IceBagMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        private void Update()
        {
            transform.Translate(Vector3.down * _speed * Time.deltaTime);
            TryDisable();
        }

        private void TryDisable()
        {
            if (transform.position.y <= Grid.MinPositionY)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
