using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerUI;
    public float CurrentTime { get; private set; }

    void Update()
    {
        CurrentTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(CurrentTime);

        string hours;
        if (time.Hours < 10) hours = "0" + time.Hours.ToString();
        else hours = time.Hours.ToString();

        string minutes;
        if (time.Minutes < 10) minutes = "0" + time.Minutes.ToString();
        else minutes = time.Minutes.ToString();

        string seconds;
        if (time.Seconds < 10) seconds = "0" + time.Seconds.ToString();
        else seconds = time.Seconds.ToString();

        timerUI.text = "Time: " + hours + ":" + minutes + ":" + seconds;
    }

    public void SetTime(float time) => CurrentTime = time;
}
