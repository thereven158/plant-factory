using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public SceneFader sceneFader;

    public GameObject pausedUI;
    public int levelToUnlock;

    //public SceneFader fader;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    
    public void CheckPaused ()
    {
        if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    void Resume ()
    {
        pausedUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pausedUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        //fader.FadeToLevel(SceneManager.GetActiveScene().buildIndex + 0);
        Resume();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Resume();
    }

    public void Secret()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        PlayerPrefs.SetInt("lightStageReached", levelToUnlock);
        sceneFader.FadeToLevel(levelToUnlock);
    }
}
