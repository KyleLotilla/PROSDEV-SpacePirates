using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DLSU.SpacePirates.Util
{
    public class OnDestroyEvent : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onDestroy;

        private void OnDestroy()
        {
            onDestroy.Invoke();
        }
    }
}

