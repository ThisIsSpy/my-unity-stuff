using UnityEngine;

public class ScoreDataConverter : JsonDataConverter<ScoreData>
{
    private readonly Score score;

    public ScoreDataConverter(Score score)
    {
        this.score = score;
    }

    public override void UnconvertData(ScoreData data)
    {
        score.ScoreCount = data.score;
    }

    public override ScoreData ConvertData()
    {
        ScoreData data = new() { score = score.ScoreCount };
        return data;
    }
}
