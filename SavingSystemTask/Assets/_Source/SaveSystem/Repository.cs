using UnityEngine;

public class Repository
{
    private readonly IFileSaver fileSaver;
    private readonly IDataConverter[] dataConverters;
    
    public Repository(IFileSaver fileSaver, IDataConverter[] savers)
    {
        this.fileSaver = fileSaver;
        this.dataConverters = savers;
    }

    public void Save()
    {
        foreach (var s in dataConverters)
        {
            fileSaver.Save(GetKey(s), s.Convert());
        }
    }

    public void Load()
    {
        foreach (var s in dataConverters)
        {
            string data = fileSaver.Load(GetKey(s));
            if (data != null && data != string.Empty) s.Unconvert(data);
        }
    }

    private string GetKey(IDataConverter saver) => saver.GetType().Name;
}
