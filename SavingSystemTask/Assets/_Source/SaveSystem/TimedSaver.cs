using System.Collections;
using TMPro;
using UnityEngine;

public class TimedSaver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI saveNotification;
    [SerializeField] private float saveInterval;
    private Repository repository;
    private float elapsedTime;

    public void Construct(Repository repository)
    {
        this.repository = repository;
    }

    void Update()
    {
        if(repository == null) return;
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= saveInterval)
        {
            repository.Save();
            StartCoroutine(DisplayNotification());
            elapsedTime = 0;
        }
    }

    private IEnumerator DisplayNotification()
    {
        saveNotification.text = "Saving...";
        yield return new WaitForSeconds(3);
        saveNotification.text = string.Empty;
    }
}
