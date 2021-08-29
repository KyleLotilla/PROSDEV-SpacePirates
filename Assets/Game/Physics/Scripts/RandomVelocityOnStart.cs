using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Physics
{
    public class RandomVelocityOnStart : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D objectRigidBody;
        [SerializeField]
        private Vector2 minSpeed;
        [SerializeField]
        private Vector2 maxSpeed;

        // Start is called before the first frame update
        void Start()
        {
            float[] directions = new float[2] { -1.0f, 1.0f };
            float randomVelocityX = Random.Range(minSpeed.x, maxSpeed.x) * directions[Random.Range(0, 2)];
            float randomVelocityY = Random.Range(minSpeed.y, maxSpeed.y) * directions[Random.Range(0, 2)];
            objectRigidBody.velocity = new Vector2(randomVelocityX, randomVelocityY);
        }
    }

}
