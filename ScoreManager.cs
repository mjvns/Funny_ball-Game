using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {

    public static ScoreManager instance;
    public int score;
    public int highScore;

    void Awake(){
        if (instance == null) {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        score = 0;
        PlayerPrefs.SetInt("score", score);
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.HasKey("highscore"))
        {
            if (PlayerPrefs.GetInt("highscore") < score)
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        highScore = PlayerPrefs.GetInt("highscore");
        PlayerPrefs.SetInt("score", score);
    }

    void IncrementScore() {
        score += 1;
    }

    public void IncrementOnCollisionWithDiamond() {
        score += 3;
    }

    public void StartScore() {
        InvokeRepeating("IncrementScore", 0.2f, 1.0f);
    }

    public void EndScore() {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score", score);

        if (PlayerPrefs.HasKey("highscore"))
        {
            if (PlayerPrefs.GetInt("highscore") < score)
            {
                PlayerPrefs.SetInt("highscore", score);
            }
        }
        else {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
}
