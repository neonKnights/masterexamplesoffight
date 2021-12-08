using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(WaypointPath))]
public class WaypointPathEditor : Editor
{
    SerializedProperty waypointsProp;
    void OnEnable()
    {
        waypointsProp = serializedObject.FindProperty("waypoints");
    }
    public void OnSceneGUI()
    {
        int waypointsLen = waypointsProp.arraySize;
        for (int i = 0; i < waypointsLen; i++)
        {
            SerializedProperty element = waypointsProp.GetArrayElementAtIndex(i);

            element.vector3Value = Handles.PositionHandle(element.vector3Value, Quaternion.identity);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
