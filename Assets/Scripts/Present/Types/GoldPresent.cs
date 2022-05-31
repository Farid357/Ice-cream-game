namespace IceCream.GameLogic
{
    public sealed class GoldPresent : Present
    {
        private const int GoldCount = 1;
        private GoldPresentsCollector _collector;

        protected override void PlayApplyFeedBack()
        {
            _collector.Add(GoldCount);
        }

        public void Init(GoldPresentsCollector collector) => _collector = collector;
    }
}
