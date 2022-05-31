using System;

namespace IceCream.GameLogic
{
    public sealed class NightPresent : Present
    {
        private SunRays _sunRays;
        private int _seconds;

        public void Init(SunRays sunRays, int seconds)
        {
            _sunRays = sunRays ?? throw new ArgumentNullException(nameof(sunRays));
            _seconds = seconds;
        }

        protected override void PlayApplyFeedBack()
        {
           _sunRays.StopFryForSeconds(_seconds);
        }
    }
}
