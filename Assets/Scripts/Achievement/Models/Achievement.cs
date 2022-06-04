using IceCream.GameLogic;
using IceCream.SaveSystem;
using System;
using Zenject;

namespace IceCream.Achievement
{
    public abstract class Achievement
    {
        public event Action OnClaimed;

        [Inject] private GoldPresentsCollector _collector;
        private readonly IStorage _storage = new BinaryStorage();
        private string _key;
        private int _goldCount;
        public bool IsApplyed { get; private set; }

        public void Init(int goldCount, string key, GoldPresentsCollector collector)
        {
            _goldCount = goldCount;
            _key = key;
            IsApplyed = _storage.Load<bool>(_key);
            _collector = collector;
        }

        public void TryApply()
        {
            if (CanBuy() && !IsApplyed)
            {
                if (_collector is null) throw new SystemException(nameof(_collector));
                _collector.Add(_goldCount);
                IsApplyed = true;
                _storage.Save(_key, IsApplyed);
                OnClaimed.Invoke();
            }
        }

        protected abstract bool CanBuy();
    }
}
