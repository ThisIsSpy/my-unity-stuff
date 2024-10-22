using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputListener : MonoBehaviour
{
    private SceneReloader _sceneReloader;
    private void Update()
    {
        ReadReloadInput();
    }
    private void ReadReloadInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _sceneReloader.ReloadScene();
        }
    }
    public void SetReloader(SceneReloader reloader)
    {
        _sceneReloader = reloader;
    }
}
