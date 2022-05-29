using System;
using UnityEngine;

namespace IceCream.GameLogic
{
    public abstract class Damagable : MonoBehaviour
    {
        public event Action OnEnded;
        public Action<float> OnChanged;
        [SerializeField] private float _health;
        [SerializeField] private bool _needHealthReload;
        private float _maxHealth;

        public float Health { get => _health; protected set => _health = value; }

        private void OnEnable()
        {
            if (_needHealthReload)
                _health = _maxHealth;
        }

        public void ApplyDamage(in float damage)
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
        public void SetHealth(float health)
        {
            if (health <= 0) throw new ArgumentOutOfRangeException(nameof(health));
            _health = health;
            _maxHealth = health;
        }

        protected abstract void PlayChangeHealthFeedback();
    }
}
