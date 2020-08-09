using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public bool sfxState;
    public bool musicState;

    public Image sfx;
    public Image music;
    public Sprite sfxOn;
    public Sprite sfxOff;
    public Sprite musicOn;
    public Sprite musicOff;

    public GameObject codeInput;
    public GameObject[] buttons;

    public void SFX()
    {
        if (sfxState)
        {
            sfxState = false;
            sfx.sprite = sfxOff;
        }
        else
        {
            sfxState = true;
            sfx.sprite = sfxOn;
        }

        FindObjectOfType<GameManager>().sfxOn = sfxState;
    }

    public void Music()
    {
        if (musicState)
        {
            musicState = false;
            music.sprite = musicOff;

            FindObjectOfType<AudioManager>().Stop("Theme");
        }
        else
        {
            musicState = true;
            music.sprite = musicOn;

            FindObjectOfType<AudioManager>().Play("Theme");
        }

        FindObjectOfType<GameManager>().musicOn = musicState;
    }

    public void SubmitCode()
    {
        codeInput.SetActive(true);
        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
    }

    public void CancelCode()
    {
        codeInput.SetActive(false);
        foreach (GameObject button in buttons)
        {
            button.SetActive(true);
        }
    }

    public void Tutorial()
    {
        FindObjectOfType<LevelLoader>().LoadTutorial();
    }
}
