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
}
