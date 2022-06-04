using System.Collections;
using TMPro;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class ScoreView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _count;
        [SerializeField] private TextMeshProUGUI _bestRecord;
        [SerializeField] private Score _score;
        [SerializeField] private float _scaleDelay = 0.4f;
        [SerializeField] private float _increaseScaleCofficient = 1.2f;

        private void OnEnable()
        {
            _score.OnChanged += Display;
            _score.OnGotNewRecord += StartDisplayRecord;
        }

        private void OnDestroy()
        {
            _score.OnChanged -= Display;
            _score.OnGotNewRecord -= StartDisplayRecord;
        }

        private void Display(int count)
        {
            _count.text = count.ToString();
        }

        private void StartDisplayRecord(int count)
        {
           _bestRecord.text = count.ToString();
          //  StartCoroutine(DisplayRecord());
        }

        private IEnumerator DisplayRecord()
        {
            var scale = _bestRecord.transform.localScale;
            _bestRecord.transform.localScale = scale * _increaseScaleCofficient;
            yield return new WaitForSeconds(_scaleDelay);
            _bestRecord.transform.localScale = scale;
        }
    }
}