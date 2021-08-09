using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDestroy : MonoBehaviour
{
    public GameObject obstacle;
    public AudioSource audioSource;

    public void ExplosionComplete()
    {
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        while (audioSource.isPlaying)
            yield return null;
        Destroy(obstacle);
    }
}
