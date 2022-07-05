using UnityEngine;
using UnityEngine.UI;

namespace IceCream.App
{
    public sealed class AppState : MonoBehaviour
    {
        [SerializeField] private Button _pause;
        [SerializeField] private GameObject _pausePanel;
        [SerializeField] private Button _restart;

        private void Awake()
        {
            _pause.onClick.AddListener(Pause);
            _restart.onClick.AddListener(() => Time.timeScale = 1);
        }

        private void Pause()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        public void Lose() => Time.timeScale = 0;
    }
}