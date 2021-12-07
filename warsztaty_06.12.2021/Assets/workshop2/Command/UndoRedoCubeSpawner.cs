using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class UndoRedoCubeSpawner : MonoBehaviour
{
    [SerializeField]
    Camera myCamera;
    [SerializeField]
    private Transform cubePrefab;
    [SerializeField]
    private ObjectPooling<Transform> cubePool;
    private UndoRedoSystem urs;


    // Start is called before the first frame update
    void Start()
    {
        cubePool = new ObjectPooling<Transform>(CreateCube, OnCubeGet, OnCubeRelease, DestroyCube);
        urs = new UndoRedoSystem();
    }
    
    private Transform CreateCube() {
        return Instantiate(cubePrefab);
    }

    private void DestroyCube(Transform cube) {
        Destroy(cube.gameObject);
    }

    private void OnCubeGet(Transform cubeTransform) {
        cubeTransform.gameObject.SetActive(true);
    }

    private void OnCubeRelease(Transform cubeTransform) {
        cubeTransform.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame) {
            Vector2 position = Mouse.current.position.ReadValue();
            Ray ray = myCamera.ScreenPointToRay(position);
            Vector3 spawnPos = ray.GetPoint(20);
            urs.Do(new CreateCubeCommand(cubePool, spawnPos));
        }
        if (Mouse.current.rightButton.wasPressedThisFrame) {
            urs.Undo();
        }
    }
}
