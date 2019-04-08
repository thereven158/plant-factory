using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    public GameObject winUI;

    public SceneFader sceneFader;
    public int levelToUnlock;

    public void WinStage()
    {
        winUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void NextStage()
    {
        winUI.SetActive(false);
        PlayerPrefs.SetInt("lightStageReached", levelToUnlock);
                   
        sceneFader.FadeToLevel(levelToUnlock);
    }

    public void MainMenu()
    {
        winUI.SetActive(false);
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        Time.timeScale = 1f;
    }
}
