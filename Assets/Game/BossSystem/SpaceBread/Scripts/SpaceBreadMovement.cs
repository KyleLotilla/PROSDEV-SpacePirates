using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.BossSystem.SpaceBread
{
    public class SpaceBreadMovement : MonoBehaviour
    {
        [SerializeField]
        private float topBound;
        [SerializeField]
        private float buttomBound;
        [SerializeField]
        private Rigidbody2D shipRigidbody;
        [SerializeField]
        private float speed;

        // Start is called before the first frame update
        void Start()
        {
            shipRigidbody.velocity = new Vector2(0.0f, speed);
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.y >= topBound)
            {
                shipRigidbody.velocity = new Vector2(0.0f, -speed);
            }
            else if (transform.position.y <= buttomBound)
            {
                shipRigidbody.velocity = new Vector2(0.0f, speed);
            }
        }
    }
}

