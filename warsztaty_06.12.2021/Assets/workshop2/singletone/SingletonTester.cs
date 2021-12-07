using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonTester : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Singletone.Instance.LogSomeMessage();
        Debug.Log(TranslationSystem.Instance.Translate("key"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
