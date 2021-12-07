using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfacesTester : MonoBehaviour
{
    [SerializeField]
    private Cat cat;
    // Start is called before the first frame update
    void Start()
    {
        IBeing being = cat;
        being.Eat();
        Debug.Log(cat.hunger);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
