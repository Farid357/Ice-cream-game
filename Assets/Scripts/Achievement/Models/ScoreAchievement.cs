using IceCream.GameLogic;

namespace IceCream.Achievement
{
    public sealed class ScoreAchievement : Achievement
    {
        private readonly int _needScore;
        private readonly Score _score;

        public ScoreAchievement(Score score, int needScore)
        {
            _score = score;
            _needScore = needScore;
        }

        protected override bool CanBuy() => _score.Count >= _needScore;
    }
}
