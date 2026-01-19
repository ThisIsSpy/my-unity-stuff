using UnityEngine;

public interface IFileSaver
{
    public void Save(string key, string data);
    public string Load(string key);
}
