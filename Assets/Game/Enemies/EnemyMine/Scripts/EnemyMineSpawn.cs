using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMineSpawn : IObstacleSpawn
{
    public EnemyMineMovement prefab;

    public EnemyMineSpawn()
    {
        prefab = Resources.Load<EnemyMineMovement>("Prefabs/EnemyMine");
    }
    
    public void SpawnObstacle(Vector2 spawnPosition, float speed)
    {
        EnemyMineMovement enemyMine = Object.Instantiate(prefab, spawnPosition, Quaternion.identity);
        enemyMine.speed = speed;
    }
}
