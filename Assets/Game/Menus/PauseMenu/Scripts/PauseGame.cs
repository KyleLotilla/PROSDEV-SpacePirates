using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
	public GameObject Panel;
	public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
     	{
         	if(Panel.activeSelf){
         		Panel.SetActive(false);
             	Time.timeScale = 1;
         	}
         	else if(!Player.activeSelf){
         		Panel.SetActive(false);
         	}
         	else if(!Panel.activeSelf){
         		Panel.SetActive(true);
             	Time.timeScale = 0;
         	}
     	}
    }

    public void Resume(){
        Panel.SetActive(false);
        Time.timeScale = 1;
    }

    public void Quit()
    {
    	Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
}
