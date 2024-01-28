using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Rigidbody2D rd;
    public float speedX;
    public float speedY;

    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Rigidbody2D>();
        speedX = 1;
        speedY = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        rd.velocity = new Vector2(speedX, speedY);
        if(transform.position.x > 1)
        {
            speedX = -1;
        }
        else if(transform.position.x < -1)
        {
            speedX = 1;
        }

        if (transform.position.y > 1)
        {
            speedY = -0.7f;
        }
        else if(transform.position.y < -1)
        {
            speedY = 0.7f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(gameObject);
        }
        
    }
}
