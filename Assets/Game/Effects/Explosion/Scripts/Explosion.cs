using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.SpacePirates.Effects
{
    public class Explosion : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private AudioClip explosionSound;
        [SerializeField]
        [Range(0.0f, 1.0f)]
        private float explosionVolume = 1.0f;
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
            AudioSource.PlayClipAtPoint(explosionSound, new Vector3(0.0f, 0.0f), explosionVolume);
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

