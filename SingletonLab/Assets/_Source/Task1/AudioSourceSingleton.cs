using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class AudioSourceSingleton : MonoBehaviour
{
    public static AudioSourceSingleton Instance { get; private set; }

    private void Awake()
    {
        if (Instance==null)
        {
            Instance = new();
            DontDestroyOnLoad(gameObject);
            return;
        }
        Destroy(gameObject);
    }
}
