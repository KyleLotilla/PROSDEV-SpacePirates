using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.BossSystem.AlienHead
{
    public class AlienHeadMovement : MonoBehaviour
    {
        [SerializeField]
        private float topBound;
        [SerializeField]
        private float buttomBound;
        [SerializeField]
        private Rigidbody2D shipRigidbody;
        [SerializeField]
        private float speed;
        [SerializeField]
        private float rightBound;
        [SerializeField]
        private float leftBound;


        // Start is called before the first frame update
        void Start()
        {
           shipRigidbody.velocity = new Vector2(speed, speed);
           //shipRigidbody.velocity = new Vector2(speed, 0.0f);
        }

        // Update is called once per frame
        void Update()
        {
            ForwardAttack();
            RegularMovement();
        }

        public void RegularMovement()
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

        public void ForwardAttack()
        {
            
            if (transform.position.x >= rightBound)
            {
                shipRigidbody.velocity = new Vector2(-speed * 2, 0.0f);
            }

            else if (transform.position.x <= leftBound)
            {
                shipRigidbody.velocity = new Vector2(speed, 0.0f);
            }
        }
    }
}

