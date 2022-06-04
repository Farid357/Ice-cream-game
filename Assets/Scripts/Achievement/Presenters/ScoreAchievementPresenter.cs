using IceCream.GameLogic;
using Zenject;

namespace IceCream.Achievement
{
    public sealed class ScoreAchievementPresenter : AchievementPresenter
    {
        private Score _score;

        protected override Achievement Get()
        {
            return new ScoreAchievement(_score, NeedCount);
        }

        [Inject]
        public void Init(Score score) => _score = score;
    }
}
