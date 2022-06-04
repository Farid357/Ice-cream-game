using UnityEngine;
using UnityEngine.UI;

namespace IceCream.App
{
    public sealed class AppState : MonoBehaviour
    {
        [SerializeField] private Button _pause;
        [SerializeField] private GameObject _pausePanel;

        private void Awake() => _pause.onClick.AddListener(Pause);

        private void Pause()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Lose() => Time.timeScale = 0;
    }
}