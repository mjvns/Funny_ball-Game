using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour {

    public static UiManager instance;

    public GameObject funnyballPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject SwapleftPanel;
    public GameObject ScorePanel;
    public Text score;
    public Text highScore1;
    public Text highScore2;
    public Text ActualScoreheading;
    public Text actualScore;

    void Awake(){
        if (instance == null) {
            instance = this;
        }
    }


    // Use this for initialization
    void Start () {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highscore").ToString();
    }

    public void GameStart() {
        tapText.SetActive(false);
        ScorePanel.SetActive(true);
        funnyballPanel.GetComponent<Animator>().Play("panelUp");
        SwapleftPanel.GetComponent<Animator>().Play("Swapleft");
    }

    public void GameOver() {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highscore").ToString();
        gameOverPanel.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene(0);
    }
	
	// Update is called once per frame
	void Update () {
        actualScore.text = PlayerPrefs.GetInt("score").ToString();
	}
}
