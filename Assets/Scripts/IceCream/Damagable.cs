using System;
using UnityEngine;

namespace IceCream.GameLogic
{
    public abstract class Damagable : MonoBehaviour
    {
        public event Action OnEnded;
        public event Action<int> OnChanged;
        [SerializeField] private int _health;

        private int _newHealth;

        private void OnEnable() => _health = _newHealth;

        public void ApplyDamage(in int damage)
        {
            if (damage <= 0) throw new ArgumentOutOfRangeException(nameof(damage));
            _health -= damage;
            TryDie();
            OnChanged?.Invoke(_health);
            PlayChangeHealthFeedback();
        }
        private void TryDie()
        {
            if (_health <= 0)
            {
                OnEnded?.Invoke();
                gameObject.SetActive(false);
            }
        }
        public void SetHealth(int health)
        {
            if (health <= 0) throw new ArgumentOutOfRangeException(nameof(health));
            _health = health;
            _newHealth = health;
        }

        protected abstract void PlayChangeHealthFeedback();
    }
}
