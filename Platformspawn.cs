using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Platformspawn : MonoBehaviour {

    Vector3 lastPos;
    float size;
    public GameObject platform;
    public GameObject diamond;
    public bool gameOver;

	// Use this for initialization
	void Start () {
        gameOver = false;
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
	}

    public void StartPlatformSpawn() {
        InvokeRepeating("SpawnPlatforms", 1.0f, 0.2f);
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.gameOver == true) {
            CancelInvoke("SpawnPlatforms");
        }
	}

    void SpawnX() {
        Vector3 pos = lastPos;
        pos.x += size;   // increment the x position to the size of the platform along x direction
        Instantiate(platform,pos,Quaternion.identity); // instantiate the platform without any rotation
        lastPos = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1) {
            Instantiate(diamond, new Vector3(pos.x,pos.y+1,pos.z), diamond.transform.rotation);
        }
    }

    void SpawnZ() {
        Vector3 pos = lastPos;
        pos.z += size;   // increment the x position to the size of the platform along x direction
        Instantiate(platform, pos, Quaternion.identity); // instantiate the platform without any rotation
        lastPos = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1) {
            Instantiate(diamond, new Vector3(pos.x,pos.y+1,pos.z), diamond.transform.rotation);
        }
    }

    void SpawnPlatforms() {
        int rand = Random.Range(0, 6);
        if (rand < 3){
            SpawnX();
        }
        else {
            SpawnZ();
        }
    }
}
