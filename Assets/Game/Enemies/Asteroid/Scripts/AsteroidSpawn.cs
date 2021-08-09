using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawn : IObstacleSpawn
{
    public AsteroidMovement prefab;

    public AsteroidSpawn()
    {
        prefab = Resources.Load<AsteroidMovement>("Prefabs/Asteroid");
    }

    public void SpawnObstacle(Vector2 spawnPosition, float speed)
    {
        AsteroidMovement asteroid = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
        asteroid.speed = speed;
    }
}