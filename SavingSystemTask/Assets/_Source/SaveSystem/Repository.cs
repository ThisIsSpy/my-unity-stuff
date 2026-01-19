using UnityEngine;

public class Repository
{
    private readonly IFileSaver fileSaver;
    private readonly IFeatureSaver[] savers;
    
    public Repository(IFileSaver fileSaver, IFeatureSaver[] savers)
    {
        this.fileSaver = fileSaver;
        this.savers = savers;
    }

    public void Save()
    {
        foreach (var s in savers)
        {
            fileSaver.Save(GetKey(s), s.Save());
        }
    }

    public void Load()
    {
        foreach (var s in savers)
        {
            string data = fileSaver.Load(GetKey(s));
            if (data != null && data != string.Empty) s.Load(data);
        }
    }

    private string GetKey(IFeatureSaver saver) => saver.GetType().Name;
}
