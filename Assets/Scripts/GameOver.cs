using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public void QuitClicked()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }

    public void RestartClicked()
    {
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
    }
}
