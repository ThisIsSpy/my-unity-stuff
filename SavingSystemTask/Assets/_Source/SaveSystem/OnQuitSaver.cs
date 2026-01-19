using UnityEngine;

public class OnQuitSaver : MonoBehaviour
{
    private Repository repository;

    public void Construct(Repository repository)
    {
        this.repository = repository;
    }

    private void OnApplicationQuit()
    {
        repository.Save();
    }
}
