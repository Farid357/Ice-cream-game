using UnityEngine.EventSystems;
using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class ElementScaleView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private float _increaseCofficient = 1.5f;
        private Transform _enterTransform;
        private Vector3 _scale;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _enterTransform = eventData.pointerCurrentRaycast.gameObject.transform;
            _scale = _enterTransform.localScale;
            _enterTransform.localScale = _scale * _increaseCofficient;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _enterTransform.localScale = _scale;
        }
    }
}
