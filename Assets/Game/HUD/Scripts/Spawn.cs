using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float top;
    public float bottom;
    public float spawnRate = 2f;
    public float nextSpawn;
    public float speed = 1.0f;

    List<IObstacleSpawn> spawn;
    float randY;
    Vector2 whereToSpawn;
    int spawningObstacle;

    void Start()
    {
        top = 3.87f;
        bottom = -4.22f;
        spawn = new List<IObstacleSpawn>();
        //spawn.Add(new AsteroidSpawn());
        //spawn.Add(new BlackholeSpawn());
        spawn.Add(new EnemySpawn());
        StartCoroutine(SpeedUpdate());
        StartCoroutine(SpawnUpdate());
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            randY = Random.Range(bottom, top);
            whereToSpawn = new Vector2(transform.position.x, randY);
            spawningObstacle = Random.Range(0, spawn.Count);
            spawn[spawningObstacle].SpawnObstacle(whereToSpawn, speed);
        }
    }

    IEnumerator SpeedUpdate()
    {
        while (speed < 4.00f)
        {
            yield return new WaitForSeconds(5);
            speed += 0.15f;
        }
    }


    IEnumerator SpawnUpdate()
    {
        while (spawnRate > 0.4)
        {
            yield return new WaitForSeconds(3);
            spawnRate -= 0.1f;
        }

    }
}
