using System;
using System.Threading.Tasks;
using UnityEngine;

namespace IceCream.GameLogic
{
    public static class TaskExtension
    {
        public static async void Change(this Task task, float endValue, float duration, Action<float> callback, float startValue)
        {
            float elapsed = 0;
            float nextValue;

            while (elapsed < duration)
            {
                nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
                callback.Invoke(nextValue);
                elapsed += Time.deltaTime;
                await Task.Yield();
            }
        }
    }
}
