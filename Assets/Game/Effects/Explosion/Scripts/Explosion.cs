using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DLSU.SpacePirates.Util;

namespace DLSU.SpacePirates.Effects.Explosion
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private bool destroyOnFinish;
        [SerializeField]
        private UnityEvent OnExplosionStart;
        [SerializeField]
        private UnityEvent OnExplosionFinished;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Explode()
        {
            OnExplosionStart?.Invoke();
            animator.SetBool("explode", true);
        }

        public void ExplosionFinished()
        {
            OnExplosionFinished?.Invoke();
            if (destroyOnFinish)
            {
                Destroy(gameObject);
            }
        }
    }
}

