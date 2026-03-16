using UnityEngine;

public interface IDataConverter
{
    public string Convert();
    public void Unconvert(string data);
}
