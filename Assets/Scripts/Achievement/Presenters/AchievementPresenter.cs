using UnityEngine;
using IceCream.GameLogic;
using Zenject;

namespace IceCream.Achievement
{
    [RequireComponent(typeof(AchievementView))]
    public abstract class AchievementPresenter : MonoBehaviour
    {
        [SerializeField] private int _goldCount;
        [SerializeField] private GoldPresentsCollector _collector;
        private string _key;
        private AchievementView _view;
        private Achievement _achievement;
        [field: SerializeField] protected int NeedCount { get; private set; }

        private void Awake()
        {
            _achievement = Get();
            _key = gameObject.name + _goldCount + _achievement.ToString() + "k";
            _view = GetComponent<AchievementView>();
            _achievement.OnClaimed += _view.ShowPanel;
            _achievement.Init(_goldCount, _key, _collector);
            _view.Enable(_achievement.IsApplyed);
        }

        private void OnDestroy() => _achievement.OnClaimed -= _view.ShowPanel;

        public void Init(string text, int goldCount, int needCount)
        {
            _view = GetComponent<AchievementView>();
            _goldCount = goldCount;
            _view.SetText(text);
            NeedCount = needCount;
        }

        private void Update()
        {
            _achievement.TryApply();
        }

        protected abstract Achievement Get();

        [Inject]
        public void Constructor(GoldPresentsCollector collector) => _collector = collector;
    }
}
