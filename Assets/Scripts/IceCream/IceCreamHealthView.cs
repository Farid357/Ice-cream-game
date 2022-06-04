using System.Threading.Tasks;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class IceCreamHealthView : MonoBehaviour
    {
        [SerializeField] private IceCreamHealth _iceCreamHealth;
        [SerializeField] private HealthBar _bar;
        private float _health;

        private void OnEnable()
        {
            _iceCreamHealth.OnChanged += SetBarSize;
            _iceCreamHealth.OnRemoved += StartChangeLayerColor;
        }

        private void OnDestroy()
        {
            _iceCreamHealth.OnChanged -= SetBarSize;
            _iceCreamHealth.OnRemoved -= StartChangeLayerColor;
        }

        private void SetBarSize(float health)
        {
            _bar.ChangeBarSize(endValue: health, 0.4f);

            if (_iceCreamHealth.Health < _health)
               _bar.ChangeBarColor();
            _health = health;
        }

        private void StartChangeLayerColor(Layer layer)
        {
            Task task = null;
            task.Change(0f, 0.8f, (nextValue) => layer.SetAlpha(nextValue), 1);
        }
    }
}
