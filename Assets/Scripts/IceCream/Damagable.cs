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

        public float Health => _health;

        private void Awake() => _maxHealth = _health;

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

        public void Init(float health)
        {
            if (health <= 0) throw new ArgumentOutOfRangeException(nameof(health));
            _health = health;
            _maxHealth = _health;
        }

        private void TryDie()
        {
            if (_health <= 0)
            {
                OnEnded?.Invoke();
                gameObject.SetActive(false);
            }
        }

        public void TryHeal(float health)
        {
            if (_health + health <= _maxHealth)
            {
                _health += health;
                OnChanged.Invoke(Health);
                PlayHealFeedBack();
            }
        }

        protected virtual void PlayHealFeedBack() { }

        protected abstract void PlayChangeHealthFeedback();
    }
}
