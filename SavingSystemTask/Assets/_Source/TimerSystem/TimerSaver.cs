using UnityEngine;

public class TimerSaver : JsonFeatureSaver<TimerData>
{
    private readonly Timer timer;

    public TimerSaver(Timer timer)
    {
        this.timer = timer;
    }

    public override void LoadData(TimerData data)
    {
        timer.SetTime(data.time);
    }

    public override TimerData SaveData()
    {
        TimerData data = new TimerData() { time = timer.CurrentTime };
        return data;
    }
}
