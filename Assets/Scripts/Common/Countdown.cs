namespace Common
{
    public sealed class Countdown
    {
        private const float StartTime = 0.0f;
        private float _currentTime;
        
        private readonly float _duration;
        
        public Countdown(float duration)
        {
            _duration = duration;
            _currentTime = duration;
        }

        public void Tick(float deltaTime)
        {
            _currentTime -= deltaTime;
        }

        public void Reset()
        {
            _currentTime = _duration;
        }

        public bool IsFinished()
        {
            return _currentTime <= StartTime;
        }

        public bool IsPlaying()
        {
            return _currentTime > StartTime;
        }
    }
}