using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Slider : MonoBehaviour
{
    public UnityEngine.UI.Slider timeBar;
    public float timeLimit = 10;
    private float timeRemaining;

    void Start()
    {
        timeRemaining = 0;
        timeBar.maxValue = timeLimit;
        timeBar.value = timeRemaining;
    }

    void Update()
    {
        if (timeRemaining < timeLimit)
        {
            timeRemaining += Time.deltaTime;
            timeBar.value = timeRemaining;
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("Game Over Screen");
    }
}
