using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn0 : MonoBehaviour
{
    public GameObject down;
    public GameObject up;
    public float gap = 3f;
    public float time;
    public Player0 player;

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player0>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.obstacleMove && player.isAlive)
        {
            time += Time.deltaTime;
            if (time >= Random.Range(1, gap))
            {
                float ran = Random.Range(0, 10);
                Debug.Log(ran);
                if (ran >= 5)
                {
                    Spawnup();
                }
                else
                {
                    SpawnDown();
                }
            }
        }



    }

    void SpawnDown()
    {
        Instantiate(down, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
        time = 0;
    }

    void Spawnup()
    {
        Instantiate(up, new Vector3(transform.position.x, transform.position.y + 2, 0), transform.rotation);
        time = 0;
    }
}
