using System;
using UnityEngine;

namespace IceCream.GameLogic
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class IceCreanHealth : MonoBehaviour, IDamagable
    {
        public event Action OnEnded;
        public event Action<int> OnChanged;
        [SerializeField, Tooltip("Have to be from highest to smallest")] private GameObject[] _layers;
        [SerializeField] private int _health = 3;
        private int _layerIndex;

        public int MaxHealth { get; private set; }

        private void Start()
        {
            MaxHealth = _health;
            _layerIndex = _layers.Length;
        }

        public void ApplyDamage(int damage)
        {
            if (damage <= 0) throw new ArgumentOutOfRangeException(nameof(damage));
            _health -= damage;
            _layerIndex -= damage;
            _layers[_layerIndex].SetActive(false);
            OnChanged?.Invoke(_health);
            TryDie(_health);
        }

        private void TryDie(int health)
        {
            if (health <= 0)
            {
                OnEnded?.Invoke();
                Destroy(gameObject);
            }
        }
    }

    public interface IDamagable
    {
        public void ApplyDamage(int damage);
    }
}
