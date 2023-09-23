using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public int gamePoints = 0;
    public Canvas gameOver;
    // Start is called before the first frame update
    void Start()
    {
        if(gameOver)
            gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamePoints==2)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    internal void GameOver()
    {
        if (gameOver)
            gameOver.enabled=true;
    }
}
