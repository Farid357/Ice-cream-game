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

        private void OnEnable() => _health.OnChanged += SetBarSize;

        private void OnDestroy() => _health.OnChanged -= SetBarSize;

        private void SetBarSize(float health)
        {
            health *= 0.35f;
            ChangeBarSize(_bar.size, health, 0.4f);
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
