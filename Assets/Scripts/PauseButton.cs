using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour {

    public bool isPaused = false;
    public GameObject pauseMenu;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void PauseClicked()
    {
        if(isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
            pauseMenu.SetActive(isPaused);
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
            pauseMenu.SetActive(isPaused);
        }
    }

    public void ResumeClicked()
    {
        Time.timeScale = 1;
        isPaused = false;
        pauseMenu.SetActive(isPaused);

    }

    public void QuitClicked()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    
}
