using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace IceCream.GameLogic
{
    public sealed class IceCreamHealthView : MonoBehaviour
    {
        [SerializeField] private IceCreanHealth _health;
        [SerializeField] private Scrollbar _bar;
        [SerializeField] private float _changeColorDelay = 0.4f;

        private void OnEnable()
        {
            _health.OnEnded += DestroyBar;
            _health.OnChanged += SetBarSize;
        }

        private void OnDestroy()
        {
            _health.OnEnded -= DestroyBar;
            _health.OnChanged -= SetBarSize;
        }

        private void SetBarSize(int size)
        {
            _bar.size = size * 0.55f;
            StartCoroutine(ChangeBarColor());
        }

        private IEnumerator ChangeBarColor()
        {
            var image = _bar.handleRect.GetComponent<Image>();
            var startColor = image.color;
            image.color = Color.red;
            yield return new WaitForSeconds(_changeColorDelay);
            image.color = startColor;
        }

        private void DestroyBar() => Destroy(_bar.handleRect.gameObject);
    }
}
