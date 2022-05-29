using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace IceCream.GameLogic
{
    public sealed class IceCreamHealthView : MonoBehaviour
    {
        [SerializeField] private IceCreamHealth _iceCreamHealth;
        [SerializeField] private Scrollbar _bar;
        [SerializeField] private float _changeColorDelay = 0.35f;
        private float _health;

        private void OnEnable() => _iceCreamHealth.OnChanged += SetBarSize;

        private void OnDestroy() => _iceCreamHealth.OnChanged -= SetBarSize;

        private void SetBarSize(float health)
        {
            ChangeBarSize(_bar.size, health, 0.4f);

            if (_iceCreamHealth.Health < _health)
                ChangeBarColor();
            _health = health;
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
