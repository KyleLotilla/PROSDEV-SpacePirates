using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject player;
    public AudioSource audioSource;
    public GameObject Panel;

    public void ExplosionComplete()
    {
        StartCoroutine(WaitForSound());
    }

    IEnumerator WaitForSound()
    {
        while (audioSource.isPlaying)
            yield return null;
        Destroy(player);
        Panel.SetActive(true);
    }
}
