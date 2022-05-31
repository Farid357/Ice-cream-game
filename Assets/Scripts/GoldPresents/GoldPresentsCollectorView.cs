using System.Collections;
using TMPro;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class GoldPresentsCollectorView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private float _changeColorDelay = 0.3f;
        [SerializeField] private Color _changeColor;

        public void Display(int count)
        {
            _text.text = count.ToString();
            StartCoroutine(ChangeTextColor(_text));
        }

        private IEnumerator ChangeTextColor(TextMeshProUGUI text)
        {
            var wait = new WaitForSeconds(_changeColorDelay);
            var startColor = text.color;
            text.color = _changeColor;
            yield return wait;
            text.color = startColor;
        }

    }
}
