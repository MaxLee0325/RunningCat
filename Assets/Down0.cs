using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Down0 : MonoBehaviour
{
    public Player0 player;
    public Left0 left;
    public Rigidbody2D rd;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player0>();
        rd = GetComponent<Rigidbody2D>();
        left = GameObject.FindGameObjectWithTag("left").GetComponent<Left0>();
        Physics2D.IgnoreCollision(left.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (player.obstacleMove)
        {
            rd.velocity = new Vector2(-player.moveSpeed, rd.velocity.y);
        }
        else
        {
            rd.velocity = new Vector2(0, rd.velocity.y);
        }

        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
