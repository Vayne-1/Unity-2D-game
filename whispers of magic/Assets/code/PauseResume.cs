using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public GameObject PauseScreen;
    public static bool paused;
    public KeyCode PauseButton;
   
    void Start()
    {
        paused = false;
        PauseScreen.SetActive(false);

    }

    void Update()
    {
        if (Input.GetKeyDown(PauseButton) && !paused)
        {
            Pause();
        }
        else if (Input.GetKeyDown(PauseButton) && paused)
        {
            Resume();
        }
        else if (Input.GetKeyDown(PauseButton) && paused)
        {
            Quit();
        }
    }

    public void Pause()
    {
        PauseScreen.SetActive(true);
        paused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseScreen.SetActive(false);
        paused = false;
        Time.timeScale = 1;
    }
    public void Quit()
    {
        
        Application.Quit();
    }
}

