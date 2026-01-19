using UnityEngine;

public abstract class JsonFeatureSaver<T> : IFeatureSaver
{
    public string Save()
    {
        return JsonUtility.ToJson(SaveData());
    }

    public void Load(string data)
    {
        LoadData(JsonUtility.FromJson<T>(data));
    }

    public abstract T SaveData();
    public abstract void LoadData(T data);
}
