using System.Threading.Tasks;

namespace IceCream.GameLogic
{
    public sealed class Timer
    {
        private readonly float _reloadTime = 30;
        public int PassedTime { get; private set; }

        public Timer(float reloadTime = float.PositiveInfinity) => _reloadTime = reloadTime;

        public async void Start()
        {
            while (true)
            {
                if (PassedTime >= _reloadTime)
                    PassedTime = 0;
                await Task.Delay(System.TimeSpan.FromSeconds(1));
                PassedTime += 1;
            }
        }
    }
}
