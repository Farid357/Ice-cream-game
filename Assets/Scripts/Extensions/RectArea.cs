using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(RectTransform))]
    public sealed class RectArea : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            var safeArea = Screen.safeArea;
            var minAnchor = safeArea.position;
            var maxAncor = minAnchor + safeArea.size;

            minAnchor.x /= Screen.width;
            minAnchor.y /= Screen.height;
            maxAncor.x /= Screen.width;
            maxAncor.y /= Screen.height;
            _rectTransform.anchorMin = minAnchor;
            _rectTransform.anchorMax = maxAncor;
        }
    }
}
