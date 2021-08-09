using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGObjectSpawn : MonoBehaviour
{
    public GameObject[] bgObjects;
    float top = 3.87f;
    float bottom = -4.22f;

    void Start()
    {
        StartCoroutine(spawnBGObject());
    }

    IEnumerator spawnBGObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(45);
            float randY = Random.Range(bottom, top);
            Vector2 spawnPos = new Vector2(transform.position.x, randY);
            int bgObject = Random.Range(0, bgObjects.Length);
            Instantiate(bgObjects[bgObject], spawnPos, Quaternion.identity);
        }
        
    }
}
