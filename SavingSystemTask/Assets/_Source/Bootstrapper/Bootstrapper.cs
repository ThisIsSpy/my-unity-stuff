using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private Timer timer;
    [SerializeField] private Score score;
    [SerializeField] private TimedSaver timedSaver;
    [SerializeField] private OnQuitSaver onQuitSaver;

    private TimerDataConverter timerDataConverter;
    private ScoreDataConverter scoreDataConverter;
    private Repository repository;
    private PlayerPrefsSaver playerPrefsSaver;

    private void Start()
    {
        timerDataConverter = new(timer);
        scoreDataConverter = new(score);
        playerPrefsSaver = new();
        List<IDataConverter> featureSavers = new()
        {
            scoreDataConverter,
            timerDataConverter
        };
        repository = new(playerPrefsSaver, featureSavers.ToArray());
        timedSaver.Construct(repository);
        onQuitSaver.Construct(repository);
        repository.Load();
    }
}
