using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ball; //assign camera the gameobject to follow along i.e. the ball
    Vector3 offset; //distance between the camera and the ball
    public float lerpRate;// rate by which camera will change its position to follow the ball
    public bool gameOver;

    // Use this for initialization
    void Start()
    {
        offset = ball.transform.position - transform.position;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetpos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetpos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
