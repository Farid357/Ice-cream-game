using System;
using System.Collections;
using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(BoxCollider), typeof(IceBagMovement))]
    public sealed class IceBagHealthView : Damagable
    {
        [SerializeField] private Vector3 _smallSize;

        protected override void PlayChangeHealthFeedback(float health) => ChangeSize(_smallSize, 0.5f);

        private async void ChangeSize(Vector3 smallSize, float duration)
        {
            Vector3 startScale = transform.localScale;
            transform.localScale = smallSize;
            float elapsed = 0;
            Vector3 nextValue = Vector3.zero;

            while (elapsed < duration)
            {
                nextValue = Vector3.Lerp(smallSize, startScale, elapsed / duration);
                transform.localScale = nextValue;
                elapsed += Time.deltaTime;
                await System.Threading.Tasks.Task.Yield();
            }
        }
    }
}
