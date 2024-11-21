using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="AudioDataSO", menuName ="SO/New Audio Data SO")]
public class AudioDataSO : ScriptableObject
{
    [SerializeField] private AudioType audioType;
    [SerializeField] private List<AudioData> audioDataDangerous;
    [SerializeField] private List<AudioData> audioDataFriendly;
    [SerializeField] private List<AudioData> audioDataNeutral;
    [SerializeField] private string id;
    [SerializeField][TextArea(1,10,order = 1)] private string message;
}
[Serializable]
public class AudioData
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField, Range(0,1)] private float volume;
}
public enum AudioType
{
    Dangerous = 0,
    Friendly = 1,
    Neutral = 2
}
