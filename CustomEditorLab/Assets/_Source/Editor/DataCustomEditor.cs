using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AudioDataSO))]
public class DataCustomEditor : Editor
{
    private SerializedProperty _idProperty;
    private SerializedProperty _messageProperty;
    private SerializedProperty _audioTypeProperty;
    private SerializedProperty _audioDataDangerousProperty;
    private SerializedProperty _audioDataFriendlyProperty;
    private SerializedProperty _audioDataNeutralProperty;

    private bool _isMessageActive;
    private bool _isListActive;
    private string die;
    private void Awake()
    {
        _idProperty = serializedObject.FindProperty("id");
        _messageProperty = serializedObject.FindProperty("message");
        _audioTypeProperty = serializedObject.FindProperty("audioType");
        _audioDataDangerousProperty = serializedObject.FindProperty("audioDataDangerous");
        _audioDataFriendlyProperty = serializedObject.FindProperty("audioDataFriendly");
        _audioDataNeutralProperty = serializedObject.FindProperty("audioDataNeutral");
    }
    public override void OnInspectorGUI()
    {
        EditorGUILayout.PropertyField(_idProperty);
        EditorGUILayout.PropertyField(_audioTypeProperty);
        DrawMessage();
        DrawAudioData();
        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Show Message"))
        {
            _isMessageActive = true;
        }
        if (GUILayout.Button("Show List"))
        {
            _isListActive = true;
        }
        if(GUILayout.Button("Hide All"))
        {
            _isMessageActive = false;
            _isListActive = false;
        }
        EditorGUILayout.EndHorizontal();
        serializedObject.ApplyModifiedProperties();
    }
    private void DrawMessage()
    {
        if(_isMessageActive)
        {
            EditorGUILayout.PropertyField(_messageProperty);
        }
    }
    private void DrawAudioData()
    {
        if(_isListActive)
        {
            switch(_audioTypeProperty.enumValueIndex)
            {
                case 0:
                    EditorGUILayout.PropertyField(_audioDataDangerousProperty);
                    break;
                case 1:
                    EditorGUILayout.PropertyField(_audioDataFriendlyProperty);
                    break;
                case 2:
                    EditorGUILayout.PropertyField(_audioDataNeutralProperty);
                    break;
            }
        }
    }
}
