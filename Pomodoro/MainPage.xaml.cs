namespace Pomodoro;
using System.Timers;

public partial class MainPage : ContentPage
{
    private readonly Timer _timer;
    private long _remainingTime = 0;
    private long _workInterval = 25; //seconds

    public MainPage()
    {
        InitializeComponent();
        _timer = new Timer(1000);
        _timer.Elapsed += OnTimedEvent;
        _timer.AutoReset = true;
        _timer.Enabled = false;
    }

    private void OnTimedEvent(object source, ElapsedEventArgs e)
    {
        // Update UI with the remaining time
        Device.BeginInvokeOnMainThread(() =>
        {
            RemainingTimeLabel.Text = _remainingTime.ToString();
        });
        _remainingTime--;

        if(_remainingTime == 0)
        {
            _timer.Stop();
            // TODO: Send notification
        }
    }

    private void OnStartButtonClicked(object source, EventArgs e) {
        _timer.Start();
    }
    private void OnStopButtonClicked(object source, EventArgs e) {
        _timer.Stop();
    }
    private void OnResetButtonClicked(object source, EventArgs e) {
        _timer.Stop();
        _remainingTime = _workInterval;
    }
}

