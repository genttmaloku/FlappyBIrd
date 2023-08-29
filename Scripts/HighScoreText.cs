using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreText : MonoBehaviour{
   
    private void Start(){
        
        Text highscoreText = GetComponent<Text>();
        highscoreText.text = "Highscore: " + GameManager.Instance.Highscore;
    }


}
