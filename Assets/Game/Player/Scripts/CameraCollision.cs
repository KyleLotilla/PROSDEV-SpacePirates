using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DLSU.SpacePirates.Player
{
    public class CameraCollision : MonoBehaviour
    {
        void Start()
        {
            Physics2D.IgnoreLayerCollision(0, 8);
        }
    }

}
