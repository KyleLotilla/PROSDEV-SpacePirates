using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 8);
    }
}
