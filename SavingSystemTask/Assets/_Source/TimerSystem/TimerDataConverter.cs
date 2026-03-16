using UnityEngine;

public class TimerDataConverter : JsonDataConverter<TimerData>
{
    private readonly Timer timer;

    public TimerDataConverter(Timer timer)
    {
        this.timer = timer;
    }

    public override void UnconvertData(TimerData data)
    {
        timer.SetTime(data.time);
    }

    public override TimerData ConvertData()
    {
        TimerData data = new TimerData() { time = timer.CurrentTime };
        return data;
    }
}
