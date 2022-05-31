using IceCream.SaveSystem;
using System;

namespace IceCream.GameLogic
{
    public sealed class GoldPresentsCollector
    {
        public event Action<int> OnChanged;
        private int _count;
        private readonly Storage _storage = new();

        public void UpdateCount()
        {
            _count = _storage.Load();
            OnChanged?.Invoke(_count);
        }

        public void Add(int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            _count += count;
            OnChanged?.Invoke(_count);
            _storage.Save(_count);
        }

        private sealed class Storage
        {
            private const string Key = "GoldPresents";
            private IStorage _storage = new BinaryStorage();

            public void Save(int count) => _storage.Save(Key, count);

            public int Load() => _storage.Load<int>(Key);
        }
    }
}
