using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    [SerializeField]
    private Vector3[] waypoints;

    void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2)
        {
            Debug.Log("Path is too short");
            return;
        }
        Gizmos.color = Color.red;
        int l = waypoints.Length;
        //Gizmos.DrawLine(waypoints[0], waypoints[l - 1]);
        for (int i = 0; i < l; i++)
        {
            int last = i + 1;
            if (last == l)
            {
                last = 0;
            }

            Gizmos.DrawLine(waypoints[i], waypoints[last]);
        }
    }

    void OnValidate()
    {
        if (waypoints == null || waypoints.Length < 2)
        {
            Debug.Log("Path is too short");
        }
    }
}
