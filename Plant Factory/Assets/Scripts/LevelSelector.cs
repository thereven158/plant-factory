using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{

    public SceneFader fader;

    public Button[] lightLevelButtons;
    public Button[] darkLevelButtons;
    public Button[] levelSelect;

    private void Start()
    {
        int lightStageReached = PlayerPrefs.GetInt("lightStageReached", 1);
        int darkStageReached = PlayerPrefs.GetInt("darkStageReached", 1);
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < lightLevelButtons.Length; i++)
        {
            if (i + 1 > lightStageReached)
                lightLevelButtons[i].interactable = false;
            if(lightStageReached == 4)
                PlayerPrefs.SetInt("levelReached", 2);
        }

        for (int i = 0; i < darkLevelButtons.Length; i++)
        {
            if (i + 1 > darkStageReached)
                darkLevelButtons[i].interactable = false;
        }

        for (int i = 0; i < levelSelect.Length; i++)
        {
            if (i + 1 > levelReached)
                levelSelect[i].interactable = false;
        }
    }

    public void Select (int levelIndex)
    {
        fader.FadeToLevel(levelIndex);
    }

    public void ResetLevel ()
    {
        int lightStageReached = PlayerPrefs.GetInt("lightStageReached", 1);
        int darkStageReached = PlayerPrefs.GetInt("darkStageReached", 1);
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);
    }
}
