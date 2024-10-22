using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    public InputListener InputListener { get; private set; }
    public SceneReloader SceneReloader { get; private set; }
    private void Awake()
    {
        InputListener = FindObjectOfType<InputListener>().GetComponent<InputListener>();
        SceneReloader = FindObjectOfType<SceneReloader>().GetComponent<SceneReloader>();
        InputListener.SetReloader(SceneReloader);
    }
}
