using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.SpacePirates.Util
{
    public class DestroyAnimation : MonoBehaviour
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private UnityEvent onDestroyAnimationStart;
        [SerializeField]
        private UnityEvent onDestroyAnimationFinished;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartDestroyAnimation()
        {
            onDestroyAnimationStart?.Invoke();
            animator.SetBool("destroy", true);
        }

        public void OnDestroyAnimationFinished()
        {
            onDestroyAnimationFinished?.Invoke();
            Destroy(gameObject);
        }
    }
}

