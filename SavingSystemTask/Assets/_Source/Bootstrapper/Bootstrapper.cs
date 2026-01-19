using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private Score score;
    [SerializeField] private TimedSaver timedSaver;
    [SerializeField] private OnQuitSaver onQuitSaver;

    private TimerSaver timerSaver;
    private ScoreSaver scoreSaver;
    private Repository repository;
    private PlayerPrefsSaver playerPrefsSaver;

    private void Start()
    {
        timerSaver = new(timer);
        scoreSaver = new(score);
        playerPrefsSaver = new();
        List<IFeatureSaver> featureSavers = new()
        {
            scoreSaver,
            timerSaver
        };
        repository = new(playerPrefsSaver, featureSavers.ToArray());
        timedSaver.Construct(repository);
        onQuitSaver.Construct(repository);
        repository.Load();
    }
}
