using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private float speed = 8.0f;
    public Vector3 dir;
    private bool start;
    public GameObject ball;
    bool gameOver;
    Rigidbody rb;
    public GameObject particle;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Use this for initialization
    void Start()
    {
        start = false;
        gameOver = false;
        dir = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (!start && Input.GetMouseButtonDown(0))
        {
            rb.velocity = new Vector3(speed, 0, 0);
            start = true;
            GameManager.instance.GameStart();
        }
        else if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            rb.velocity = new Vector3(0, -25f, 0);
            gameOver = true;
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            Destroy(ball, 2f);
            GameManager.instance.GameOver();
        }
        */
        float toMove = speed * Time.deltaTime;

        if (!start && Input.GetMouseButtonDown(0))
        {
            dir = Vector3.right;
            start = true;
            GameManager.instance.GameStart();
        }
        else if (Input.GetMouseButtonDown(0) && !gameOver)
        {

            if (dir == Vector3.right)
            {
                dir = Vector3.forward;
            }
            else if (dir == Vector3.forward)
            {
                dir = Vector3.right;
            }
        }
        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            rb.velocity = new Vector3(0, -25f, 0);
            gameOver = true;
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            Destroy(ball, 2f);
            GameManager.instance.GameOver();
        }

        transform.Translate(dir * toMove);
    }

    void SwitchDirection()
    {
        /*
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
        else if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        */

        if (dir == Vector3.right){
            dir = Vector3.forward;
        }
        else if (dir == Vector3.forward) {
            dir = Vector3.right;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond") {
            ScoreManager.instance.IncrementOnCollisionWithDiamond();
            Destroy(col.gameObject);
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(part, 1f);
        }
    }
}
