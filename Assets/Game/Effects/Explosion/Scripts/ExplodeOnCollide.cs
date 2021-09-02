using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Effects.Explosion
{
    public class ExplodeOnCollide : MonoBehaviour
    {
        [SerializeField]
        private Explosion explosion;
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer != LayerMask.NameToLayer("Deadzone") && enabled)
            {
                explosion.Explode();
            }
        }
    }
}


