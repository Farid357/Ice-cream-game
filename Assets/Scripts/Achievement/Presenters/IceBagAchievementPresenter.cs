using IceCream.GameLogic;
using Zenject;

namespace IceCream.Achievement
{
    public sealed class IceBagAchievementPresenter : AchievementPresenter
    {
        private IceBagCatcher _catcher;

        protected override Achievement Get()
        {
            return new IceBagAchievement(_catcher, NeedCount);
        }

        [Inject]
        private void Init(IceBagCatcher catcher) => _catcher = catcher;
    }
}
