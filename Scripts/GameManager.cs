using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    public static GameManager Instance{get;  private set;}
    public int Score {get; set;} = 0;

    public int Highscore {
        get{
            return PlayerPrefs.GetInt("Highscore");
        }
        set{
            if(value > PlayerPrefs.GetInt("Highscore")){
                PlayerPrefs.SetInt("Highscore" , value);
            }
        }
    }


    private void Awake(){

        GameManager [] gameManagers = GameObject.FindObjectsOfType<GameManager>();

        if(gameManagers.Length > 1){
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        Instance = this;
    }



    
}
