using IceCream.GameLogic;

namespace IceCream.Achievement
{
    public sealed class IceBagAchievement : Achievement
    {
        private readonly int _needCount;
        private readonly IceBagCatcher _catcher;

        public IceBagAchievement(IceBagCatcher catcher, int needCount)
        {
            _catcher = catcher;
            _needCount = needCount;
        }

        protected override bool CanBuy() => _catcher.CatchedCount >= _needCount;
    }
}
