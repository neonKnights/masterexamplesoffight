using System.Collections;
using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;
    public static T Instance {
        get {
            return instance;
        }
    }

    void Awake() {
        if (instance != null) {
            Debug.LogError("an instance of this clas already exists!");
            Destroy(this);
        } else {
            instance = this as T;
        }
    }

    public void LogSomeMessage() {
        Debug.Log("Hello World!");
    }
}
