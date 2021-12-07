using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    Camera myCamera;
    [SerializeField]
    private Transform cubePrefab;
    [SerializeField]
    private ObjectPooling<Transform> cubePool;


    // Start is called before the first frame update
    void Start()
    {
        cubePool = new ObjectPooling<Transform>(CreateCube, OnCubeGet, OnCubeRelease, DestroyCube);
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
            Transform cube = cubePool.Get();
            cube.position = spawnPos;
            StartCoroutine(DispawnWithDelay(cube));
        }
    }

    private IEnumerator DispawnWithDelay(Transform cube) {
        yield return new WaitForSeconds(2);
        cubePool.Release(cube);
    }
}
