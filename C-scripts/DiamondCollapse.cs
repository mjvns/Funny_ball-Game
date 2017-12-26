using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondCollapse : MonoBehaviour {

    public GameObject diamond;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!Physics.Raycast(transform.position, Vector3.down, 1.5f)) {
            Destroy(diamond);
        }
	}
}
