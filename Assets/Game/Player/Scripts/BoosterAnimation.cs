using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterAnimation : MonoBehaviour
{
    public Animator animBoost;
    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetAxisRaw("Horizontal") > 0f || (Input.GetAxisRaw("Horizontal") >= 0 && Input.GetAxisRaw("Vertical") != 0))
            animBoost.SetBool("move", true);
        else
            animBoost.SetBool("move", false);
    }

}
