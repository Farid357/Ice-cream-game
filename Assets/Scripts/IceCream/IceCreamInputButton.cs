using UnityEngine;
using UnityEngine.EventSystems;

namespace IceCream.GameLogic
{
    public sealed class IceCreamInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private IceCreamMovement _movement;
        [SerializeField] private Vector2 _direction;
        private bool _clicked;

        public void OnPointerDown(PointerEventData eventData)
        {
            _clicked = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _clicked = false;
        }

        private void Update()
        {
            if (_clicked)
            {
                _movement.Move(_direction.normalized);
            }
        }
    }
}
