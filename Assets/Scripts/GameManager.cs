using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeRemaining = 61;
    public bool isRunning = false;
    public Text Timee;

    private void Start()
    {
        // Starts the timer automatically
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
                timeRemaining = 0;
                isRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        Timee.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}