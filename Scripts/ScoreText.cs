using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour{

    private Text scoreText;
    private int curentScore;

    private void Start(){

        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }

    private void Update(){

        if(curentScore != GameManager.Instance.Score){
            scoreText.text = "Score: " + GameManager.Instance.Score;
            curentScore = GameManager.Instance.Score;
        }

    }
    
}
