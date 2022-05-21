using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace IceCream.GameLogic
{
    public sealed class IceCreamHealthView : MonoBehaviour
    {
        [SerializeField] private IceCreamHealth _health;
        [SerializeField] private Scrollbar _bar;
        [SerializeField] private float _changeColorDelay = 0.35f;
        private float[] _sizes = new[] { 0f, 0.5f, 0.75f };

        private void OnEnable() => _health.OnChanged += SetBarSize;

        private void OnDestroy() => _health.OnChanged -= SetBarSize;

        private void SetBarSize(int size)
        {
            ChangeBarSize(_bar.size, _sizes[size], 0.4f);
            ChangeBarColor();
        }

        private async void ChangeBarSize(float startValue, float endValue, float duration)
        {
            float elapsed = 0;
            float nextValue;

            while (elapsed < duration)
            {
                nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
                _bar.size = nextValue;
                elapsed += Time.deltaTime;
                await Task.Yield();
            }
        }

        private async void ChangeBarColor()
        {
            var image = _bar.handleRect.GetComponent<Image>();
            var startColor = image.color;
            image.color = Color.white;
            await Task.Delay(System.TimeSpan.FromSeconds(_changeColorDelay));
            image.color = startColor;
        }
    }
}
