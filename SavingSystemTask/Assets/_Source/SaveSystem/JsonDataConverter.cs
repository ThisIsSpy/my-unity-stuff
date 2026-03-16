using UnityEngine;

public abstract class JsonDataConverter<T> : IDataConverter
{
    public string Convert()
    {
        return JsonUtility.ToJson(ConvertData());
    }

    public void Unconvert(string data)
    {
        UnconvertData(JsonUtility.FromJson<T>(data));
    }

    public abstract T ConvertData();
    public abstract void UnconvertData(T data);
}
