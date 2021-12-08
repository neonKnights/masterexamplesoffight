using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    [SerializeField]
    private Material m;
    [SerializeField, Min(0)]
    private float speed = 1;
    private float Phase;
    private int faceID;
    private void OnEnable()
    {
        Phase = 0;
        faceID = Shader.PropertyToID("Vector1_26abc7a073c44bdd9d4b224d61d203ca");
    }

    // Update is called once per frame
    void Update()
    {
        Phase += Time.deltaTime * speed;
        m.SetFloat(faceID, Phase);
        if (Phase >= 1)
        {
            enabled = false;
        }
    }
}
