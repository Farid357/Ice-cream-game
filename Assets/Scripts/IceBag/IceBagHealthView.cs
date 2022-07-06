using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(BoxCollider), typeof(IceBagMovement))]
    public sealed class IceBagHealthView : Damagable
    {
        [SerializeField] private Vector3 _smallSize;
        [SerializeField] private float _healCount = 0.5f;
        private IceCreamHealth _iceCream;

        [Inject]
        public void Init(IceCreamHealth iceCream) => _iceCream = iceCream;

        protected override void PlayChangeHealthFeedback()
        {
            _iceCream.TryHeal(_healCount);
            ChangeSize(_smallSize, 0.5f);
        }

        private async void ChangeSize(Vector3 smallSize, float duration)
        {
            var startScale = transform.localScale;
            transform.localScale = smallSize;
            float elapsed = 0;

            while (elapsed < duration)
            {
                var nextValue = Vector3.Lerp(smallSize, startScale, elapsed / duration);
                transform.localScale = nextValue;
                elapsed += Time.deltaTime;
                await Task.Yield();
            }
        }
    }
}