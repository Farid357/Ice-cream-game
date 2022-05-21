using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(IceBagMovement), typeof(IceBagHealthView))]
    public sealed class IceBagInitializer : MonoBehaviour, IInitializer
    {
        private IceBagHealthView _health;

        private void OnEnable() => _health = GetComponent<IceBagHealthView>();

        public void Init()
        {
            var randomHealth = Random.Range(1, 4);
            _health.SetHealth(randomHealth);
        }
    }
}
