using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(simplePlayer))]
public class SimplePlayerEditor : Editor
{
    SerializedProperty healthProperty;
    void OnEnable()
    {
        healthProperty = serializedObject.FindProperty("health");
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.LabelField("default inspector", EditorStyles.boldLabel);
        DrawDefaultInspector();

        EditorGUILayout.LabelField("custom inspector", EditorStyles.boldLabel);
        healthProperty.intValue = EditorGUILayout.IntField("Health:", healthProperty.intValue);
        healthProperty.intValue = EditorGUILayout.IntSlider("slider", healthProperty.intValue, -46, 72);
        EditorGUILayout.PropertyField(healthProperty);
        serializedObject.ApplyModifiedProperties();
    }
}
