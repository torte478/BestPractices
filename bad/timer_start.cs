void TimerStart(bool flag)
{
    if (flag)
        _timer.Start();
    else
        _timer.Stop();
}