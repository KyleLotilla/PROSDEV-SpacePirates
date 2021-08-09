using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeSpawn : IObstacleSpawn
{
    public BlackholeMovement prefab;

    public BlackholeSpawn()
    {
        prefab = Resources.Load<BlackholeMovement>("Prefabs/Blackhole");
    }

    public void SpawnObstacle(Vector2 spawnPosition, float speed)
    {
        BlackholeMovement blackhole = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
        blackhole.speed = speed;
    }
}
