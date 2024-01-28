using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Logic : MonoBehaviour
{
    public Player0 player;
    public Button start;
    public Text text1;
    public Text text2;
    public float score;
    public GameObject gameOverScreen;
    public GameObject invertedBackGround;
    public GameObject warning;
    public float time;
    public bool trigg;
    public float changeRate;
    public float interval;
    public AudioSource normalMusic;
    public AudioSource intenseMusic;
    public bool enteredIntense;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player0>();
        start = GameObject.FindGameObjectWithTag("start").GetComponent<Button>();
        score = 0;
        time = 0;
        trigg = false;
        changeRate = 0.5f;
        interval = 6;
        normalMusic.Play();
        enteredIntense = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.started && player.isAlive)
        {
            if (Input.GetKey(KeyCode.D))
            {
                score += 10 * Time.deltaTime;
            }
            else if(Input.GetKey(KeyCode.A))
            {
                score -= 10 * Time.deltaTime;
            }

            time += Time.deltaTime;
            if(time >= (interval - 0.5))
            {
                warning.SetActive(true);
            }

            if (time >= interval)
            {
                warning.SetActive(false);
                invert();
                time = 0;
                if (interval > 2)
                {
                    interval -= changeRate;
                }
                else 
                {
                    if (!enteredIntense)
                    {
                        normalMusic.Pause();
                        intenseMusic.Play();
                        enteredIntense = true;
                    }
                }
            }
        }

        text1.text = score.ToString("0#");

        if (!player.isAlive && player.started)
        {
            gameOverScreen.SetActive(true);
            text2.text = score.ToString("0#");
        }

    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }

    public void invert()
    {
        trigg = !trigg;
        invertedBackGround.SetActive(trigg);
    }

}
