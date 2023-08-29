using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public void Start(){

        Time.timeScale = 0f;


    }

    public void StartGame(){

        Time.timeScale = 1f;
        gameObject.SetActive(false);

    }



    
}
