using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace IceCream.Achievement
{
    public sealed class AchievementView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        [SerializeField] private Image _checkMark;
        private AchievementPanel _panel;

        public void Enable(bool isClaimed) => _checkMark.gameObject.SetActive(isClaimed);

        public void SetText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentException($"\"{nameof(text)}\" не может быть пустым или содержать только пробел.", nameof(text));
            }
            _text.text = text;
        }

        public void ShowPanel()
        {
            _panel.StartShow();
            _checkMark.gameObject.SetActive(true);
        }

        [Inject]
        private void Init(AchievementPanel panel) => _panel = panel;
    }
}
