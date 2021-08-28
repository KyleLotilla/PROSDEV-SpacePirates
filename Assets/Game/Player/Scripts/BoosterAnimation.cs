using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Player
{
    public class BoosterAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        // Start is called before the first frame update
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetAxisRaw("Horizontal") > 0f || (Input.GetAxisRaw("Horizontal") >= 0 && Input.GetAxisRaw("Vertical") != 0))
                animator.SetBool("move", true);
            else
                animator.SetBool("move", false);
        }

    }
}

