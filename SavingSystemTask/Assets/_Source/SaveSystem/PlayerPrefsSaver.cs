using UnityEngine;

public class PlayerPrefsSaver : IFileSaver
{
    public void Save(string key, string data)
    {
        PlayerPrefs.SetString(key, data);
    }

    public string Load(string key)
    {
        return PlayerPrefs.GetString(key);
    }
}
