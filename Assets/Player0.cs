using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player0 : MonoBehaviour
{
    public bool forward = false;
    public float jumpForce = 10f;
    public Rigidbody2D myRidibody;
    public float gravity = 10f;
    public bool grounded = false;
    public float moveSpeed = 10f;
    public bool faceRight = true;
    public bool obstacleMove;
    public bool isAlive;
    public bool started;
    public Logic logic;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public AudioSource death;
    public AudioSource slide;
    public AudioSource jump;

    // Start is called before the first frame update
    void Start()
    {
        myRidibody = GetComponent<Rigidbody2D>();
        obstacleMove = false;
        isAlive = true;
        started = false;
        logic = GameObject.FindGameObjectWithTag("logic").GetComponent<Logic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            started = true;
        }

        if (!logic.trigg)
        {
            up = KeyCode.W;
            down = KeyCode.S;
            left = KeyCode.A;
            right = KeyCode.D;
        }
        else
        {
            up = KeyCode.S;
            down = KeyCode.W;
            left = KeyCode.D;
            right = KeyCode.A;
        }

        if (isAlive && started)
        {
            if (Input.GetKeyDown(up))
            {
                myRidibody.velocity = Vector2.up * jumpForce;
                jump.Play();
            }

            //move left
            if (Input.GetKey(left))
            {
                myRidibody.velocity = new Vector2(-moveSpeed, myRidibody.velocity.y);

                obstacleMove = false;
                Debug.Log("obStrop!");

                if (Input.GetKey(down))
                {
                    transform.localEulerAngles = new Vector3(0, 180, 90);
                    Debug.Log("SSS");
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);

                }

                faceRight = false;

            }
            else
            {
                myRidibody.velocity = new Vector2(0, myRidibody.velocity.y);
            }

            //move right when player is on the left
            if (Input.GetKey(right) && transform.position.x <= -2)
            {
                myRidibody.velocity = new Vector2(moveSpeed, myRidibody.velocity.y);
                if (Input.GetKey(down))
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                transform.localEulerAngles = new Vector3(0, 0, 0);
                faceRight = true;
            }

            //obstacle should be moving when D is held and we are at the threshold spot

            if (Input.GetKey(right) && transform.position.x > -2.5)
            {
                obstacleMove = true;
            }

            //obstacle should stop moving when D is not held
            if (Input.GetKeyUp(right))
            {
                obstacleMove = false;
            }


            if (Input.GetKey(down))
            {
                if (faceRight)
                {
                    transform.localEulerAngles = new Vector3(0, 0, 90);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 180, 90);
                }
            }

            if (Input.GetKeyDown(down))
            {
                slide.Play();
            }

            if (Input.GetKeyUp(down))
            {
                if (faceRight)
                {
                    transform.localEulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.localEulerAngles = new Vector3(0, 180, 0);
                }

            }
        }



    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("left") || collision.gameObject.CompareTag("up") || collision.gameObject.CompareTag("down"))
        {
            isAlive = false;
            death.Play();
        }

    }

}
