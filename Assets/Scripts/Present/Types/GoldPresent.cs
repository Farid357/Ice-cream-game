namespace IceCream.GameLogic
{
    public sealed class GoldPresent : Present
    {
        private int _goldCount;
        private GoldPresentsCollector _collector;

        protected override void PlayApplyFeedBack()
        {
            _collector.Add(_goldCount);
        }

        public void Init(GoldPresentsCollector collector, int goldCount)
        {
            if (goldCount == 0) throw new System.ArgumentOutOfRangeException(nameof(goldCount));
            _collector = collector;
            _goldCount = goldCount;
        }
    }
}
