using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Background
{
    public class LevelBackgroundObjectSpawner : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> backgroundObjects;
        [SerializeField]
        private float top = 3.87f;
        [SerializeField]
        private float bottom = -4.22f;
        [SerializeField]
        private float spawnRate;
        private float ticks = 0.0f;

        private void Update()
        {
            ticks += Time.deltaTime;
            if (ticks >= spawnRate)
            {
                SpawnBackgroundObject();
                ticks = 0.0f;
            }
        }

        private void SpawnBackgroundObject()
        {
            float randomPositionY = Random.Range(bottom, top);
            Vector2 spawnPosition = new Vector2(transform.position.x, randomPositionY);
            int randomBackgroundObject = Random.Range(0, backgroundObjects.Count);
            Instantiate(backgroundObjects[randomBackgroundObject], spawnPosition, Quaternion.identity);
        }
    }
}

