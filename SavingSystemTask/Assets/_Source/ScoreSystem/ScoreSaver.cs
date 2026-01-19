using UnityEngine;

public class ScoreSaver : JsonFeatureSaver<ScoreData>
{
    private readonly Score score;

    public ScoreSaver(Score score)
    {
        this.score = score;
    }

    public override void LoadData(ScoreData data)
    {
        score.ScoreCount = data.score;
    }

    public override ScoreData SaveData()
    {
        ScoreData data = new() { score = score.ScoreCount };
        return data;
    }
}
