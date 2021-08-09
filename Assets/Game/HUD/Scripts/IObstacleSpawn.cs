using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObstacleSpawn
{
    void SpawnObstacle(Vector2 spawnPosition, float speed);
}
