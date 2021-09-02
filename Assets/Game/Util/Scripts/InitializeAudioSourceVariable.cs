using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Util
{
    public class InitializeAudioSourceVariable : MonoBehaviour
    {
        [SerializeField]
        private AudioSourceVariable audioSourceVariable;
        [SerializeField]
        private AudioSource audioSource;

        private void OnEnable()
        {
            audioSourceVariable.Value = audioSource;
        }

        private void OnDisable()
        {
            audioSourceVariable.Value = null;
        }
    }
}

