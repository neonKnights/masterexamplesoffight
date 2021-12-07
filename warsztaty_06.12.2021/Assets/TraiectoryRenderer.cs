using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraiectoryRenderer : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private float vertexDistance = .5f;
    [SerializeField]
    private float maxLen = 15;

    private void ClearTraiectory() {

    }

    public void DrawTraiectory(Vector3 startPos, Vector3 startVelocity)
    {
        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(startPos);
        float currentLen = 0;
        var currentPos = startPos;
        var currentVelocity = startVelocity;
        while (currentLen < maxLen) {
            float time = vertexDistance/currentVelocity.magnitude;
            currentVelocity += Physics.gravity*time;
            Vector3 displacement = currentVelocity*time;
            currentPos += displacement;
            vertices.Add(currentPos);
            currentLen += displacement.magnitude;
        }

        lineRenderer.positionCount = vertices.Count;
        lineRenderer.SetPositions(vertices.ToArray());
    }
}
