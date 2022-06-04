using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace IceCream.GameLogic
{
    public sealed class HealthBar : MonoBehaviour
    {
        [SerializeField] private Scrollbar _bar;
        [SerializeField] private float _changeColorDelay = 0.35f;

        public void ChangeBarSize(float endValue, float duration, float startValue = 0.1f)
        {
            if (startValue == 0.1f) startValue = _bar.size;

            Task task = null;
            task.Change(endValue, duration, (nextValue) => _bar.size = nextValue, startValue);
        }

        public async void ChangeBarColor()
        {
            var image = _bar.handleRect.GetComponent<Image>();
            var startColor = image.color;
            image.color = Color.white;
            await Task.Delay(System.TimeSpan.FromSeconds(_changeColorDelay));
            image.color = startColor;
        }
    }
}
