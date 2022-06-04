using System;
using System.Collections;
using UnityEngine;

namespace IceCream.GameLogic
{
    public static class CoroutineExtension
    {
        public static void StartChange(this MonoBehaviour mono, float endValue, float duration, Action<float> callback, float startValue)
        {
            mono.StartCoroutine(Change(endValue, duration, callback, startValue));
        }

        private static IEnumerator Change(float endValue, float duration, Action<float> callback, float startValue)
        {
            float elapsed = 0;
            float nextValue;

            while (elapsed < duration)
            {
                nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
                callback.Invoke(nextValue);
                elapsed += Time.deltaTime;
                yield return null;
            }
        }
    }
}
