using UnityEngine;
using IceCream.GameLogic;

namespace IceCream.App
{
    public sealed class EndGameView : MonoBehaviour
    {
        [SerializeField] private AppState _app;
        [SerializeField] private IceCreamHealth _iceCream;
        [SerializeField] private GameObject _endGamePanel;

        private void OnEnable()
        {
            _iceCream.OnEnded += Display;
        }

        private void OnDestroy()
        {
            _iceCream.OnEnded -= Display;
        }

        private void Display()
        {
            _endGamePanel.SetActive(true);
            _app.Lose();
        }
    }
}