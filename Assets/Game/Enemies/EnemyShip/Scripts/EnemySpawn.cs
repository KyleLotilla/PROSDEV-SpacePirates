using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : IObstacleSpawn
{
    public EnemyMovement prefab;

    public EnemySpawn()
    {
        prefab = Resources.Load<EnemyMovement>("Prefabs/Enemy");
    }

    public void SpawnObstacle(Vector2 spawnPosition, float speed)
    {
        EnemyMovement enemy = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
        enemy.speed = speed;
    }
}
