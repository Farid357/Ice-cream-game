using IceCream.SaveSystem;
using System;
using UnityEngine;

namespace IceCream.GameLogic
{
    public sealed class Score : MonoBehaviour
    {
        public event Action<int> OnGotNewRecord;
        public event Action<int> OnChanged;
        private int _bestCount;

        private IStorage _storage = new BinaryStorage();
        private const string BestKey = "BestScoreCount";
        public int Count { get; private set; }

        private void Start()
        {
            _bestCount = _storage.Load<int>(BestKey);
            OnGotNewRecord?.Invoke(_bestCount);
        }

        private void Update() => AddOne();

        private void AddOne()
        {
            Count++;
            OnChanged?.Invoke(Count);
            if (_bestCount < Count)
            {
                _bestCount = Count;
                _storage.Save(BestKey, _bestCount);
                OnGotNewRecord?.Invoke(_bestCount);
            }
        }
    }
}