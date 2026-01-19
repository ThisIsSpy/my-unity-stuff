using UnityEngine;

public interface IFeatureSaver
{
    public string Save();
    public void Load(string data);
}
