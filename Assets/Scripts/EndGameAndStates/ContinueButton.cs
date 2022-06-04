using UnityEngine;
using UnityEngine.UI;

namespace IceCream.App
{
    [RequireComponent(typeof(Button))]
    public sealed class ContinueButton : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Continue);
        }

        private void Continue()
        {
            _panel.SetActive(false);
            Time.timeScale = 1;
        }
    }
}