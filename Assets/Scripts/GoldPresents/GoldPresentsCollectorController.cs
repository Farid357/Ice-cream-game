namespace IceCream.GameLogic
{
    public sealed class GoldPresentsCollectorController 
    {
        private readonly GoldPresentsCollectorView _view;
        private GoldPresentsCollector _collector;

        public void Enable()
        {
            _collector.OnChanged += _view.Display;
            _collector.UpdateCount();
        }

        public GoldPresentsCollectorController(GoldPresentsCollectorView view, GoldPresentsCollector collector)
        {
            _view = view ?? throw new System.ArgumentNullException(nameof(view));
            _collector = collector;
        }
    }
}
