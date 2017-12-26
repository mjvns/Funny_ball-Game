using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public GameObject ball;
    public GameObject background;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (background.transform.position.x < ball.transform.position.x-10) {
            background.transform.position = new Vector3(ball.transform.position.x, -10, background.transform.position.z);
        }
        if (background.transform.position.z < ball.transform.position.z-10) {
            background.transform.position = new Vector3(background.transform.position.x, -10, ball.transform.position.z);
        }
	}
}
