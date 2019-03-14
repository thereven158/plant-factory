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
        int stageReached = PlayerPrefs.GetInt("stageReached", 1);
        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < lightLevelButtons.Length; i++)
        {
            if (i + 1 > stageReached)
                lightLevelButtons[i].interactable = false;
        }

        for (int i = 0; i < darkLevelButtons.Length; i++)
        {
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
}
