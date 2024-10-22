using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReloader : MonoBehaviour
{
    public void ReloadScene()
    {
        string name = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
    }
}
