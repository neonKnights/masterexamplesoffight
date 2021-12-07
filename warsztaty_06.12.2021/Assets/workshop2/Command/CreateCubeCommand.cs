using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubeCommand : ICommand
{
    ObjectPooling<Transform> cubePool;
    private Vector3 spawnPosition;
    private Transform activeCube;

    public CreateCubeCommand(ObjectPooling<Transform> cubePool, Vector3 spawnPosition)
    {
        this.cubePool = cubePool;
        this.spawnPosition = spawnPosition;
    }

    public void Execute() {
        activeCube = cubePool.Get();
        activeCube.transform.position = spawnPosition;
    }

    public void Revert() {
        cubePool.Release(activeCube);
        activeCube = null;
    }
}
