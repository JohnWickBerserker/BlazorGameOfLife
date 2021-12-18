namespace BlazorGameOfLife.Core
{
    public class GameTemplate : GameOfLife
    {
        public int StepMs = 100;

        public bool IsPlaying = true;
        public string PlayStopButtonText = "Pause";

        public GameTemplate(int rows, int cols) : base(rows, cols)
        {
            PlaceObject(0, 0);
        }

        public event Action LoopEvent;

        public async void PlayStopAsync()
        {
            IsPlaying = !IsPlaying;
            PlayStopButtonText = IsPlaying ? "Pause" : "Play";
            await RunAsync();
        }

        public void Stop()
        {
            IsPlaying = false;
        }

        public async Task RunAsync()
        {
            while (IsPlaying)
            {
                Loop();
                LoopEvent.Invoke();
                await Task.Delay(StepMs);
            }
        }
    }
}
