using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeButton : MonoBehaviour
{
	public Animator anim;
	public Animator anim2;
	public Image button;
	public Image button2;

    public void buttonPress(){
    	anim.SetTrigger("FadeTrigger");
    	anim2.SetTrigger("FadeTrigger");
    }
}
