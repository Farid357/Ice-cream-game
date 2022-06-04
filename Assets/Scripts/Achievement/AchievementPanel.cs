using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace IceCream.Achievement
{
    public sealed class AchievementPanel : MonoBehaviour
    {
        [SerializeField] private float _delay = 1.5f;
        [SerializeField] private GameObject _panel;
        public void StartShow() => StartCoroutine(Show());

        private IEnumerator Show()
        {
            _panel.SetActive(true);
            yield return new WaitForSeconds(_delay);
            _panel.SetActive(false);
        }

    }
}
