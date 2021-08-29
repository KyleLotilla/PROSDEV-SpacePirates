using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lifetime : MonoBehaviour
{
    [SerializeField]
    private float lifeTime;
    private float ticks = 0.0f;
    // Update is called once per frame
    void Update()
    {
        ticks += Time.deltaTime;
        if (ticks >= lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
