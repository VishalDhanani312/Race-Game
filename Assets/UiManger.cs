using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UiManger : MonoBehaviour {
    public Text scoreText;
    int score;
    bool gameOver;
    public Button[] buttons;

	// Use this for initialization
	void Start () {
        gameOver = false;
        score = 0;
        InvokeRepeating("IncrementScore", 1f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
            scoreText.text = "Score: " + score;
        }
	}

    public void GameOver()
    {
        gameOver = true;
        CancelInvoke("IncrementScore");
        
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
       
    }

    void IncrementScore()
    {
        if (!gameOver)
        {
            score += 1;
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("level1");
       
    }

    public void Pause()
    {

        if(Time.timeScale == 1.0f)
        {
            Time.timeScale = 0;
        }
       else if(Time.timeScale == 0)
        {
            Time.timeScale = 1.0f;
        }
    }


    public void Menu()
    {

        SceneManager.LoadScene("Menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
