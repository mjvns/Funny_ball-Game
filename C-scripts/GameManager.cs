using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool gameOver;

    private void Awake(){
        if (instance == null) {
            instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameStart() {
        ScoreManager.instance.StartScore();
        UiManager.instance.GameStart();
        GameObject.Find("PlatformSpawner").GetComponent<Platformspawn>().StartPlatformSpawn();
    }

    public void GameOver() {
        ScoreManager.instance.EndScore();
        UiManager.instance.GameOver();
        gameOver = true;
    }
}
