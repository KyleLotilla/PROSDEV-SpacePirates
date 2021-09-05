using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Util
{
    public class DestroyAnimationOnCollide : MonoBehaviour
    {
        [SerializeField]
        private DestroyAnimation explosion;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer != LayerMask.NameToLayer("Deadzone") && enabled)
            {
                explosion.StartDestroyAnimation();
            }
        }
    }
}


