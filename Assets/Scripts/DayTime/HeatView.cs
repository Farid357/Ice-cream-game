using System.Collections;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class HeatView : MonoBehaviour
    {
        [SerializeField] private GameObject _sunHeat;
        [SerializeField] private SunRays _sunRays;
        [SerializeField] private float _delay = 1.2f;

        private void OnEnable() => _sunRays.OnHeated += StartShowHeat;

        private void OnDestroy() => _sunRays.OnHeated -= StartShowHeat;

        private void StartShowHeat() => StartCoroutine(ShowHeat());

        private IEnumerator ShowHeat()
        {
            _sunHeat.SetActive(true);
            yield return new WaitForSeconds(_delay);
            _sunHeat.SetActive(false);
        }
    }
}
