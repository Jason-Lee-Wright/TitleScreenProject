using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{
    private GameObject optionsmenu;
    private bool optionsBool;
    private float Volume = 1f;

    public List<AudioSource> audioSourcesUI;
    public List<AudioSource> audioSourcesMusic;
    public Slider VolSlideUI;
    public Slider VolSlideMusic;

    private void Awake()
    {
        optionsmenu = GameObject.FindGameObjectWithTag("Options");
        if (optionsmenu != null)
        {
            optionsBool = false;
            optionsmenu.SetActive(false);
        }

    }

    public void BPlay()
    {
        //This is where I would change scenes if I had one
    }

    public void BOptions()
    {
        if (optionsBool == false)
        {
            optionsBool = true;
            optionsmenu.SetActive(optionsBool);
            return;
        }
        else
        {
            optionsBool = false;
            optionsmenu.SetActive(optionsBool);
        }
    }

    public void BQuit()
    {
        Application.Quit();
    }

    public void SliderVolUI()
    {
        Volume = VolSlideUI.value;

        foreach (AudioSource source in audioSourcesUI)
        {
            source.volume = Volume;
        }
    }

    public void SliderVolMusic()
    {
        Volume = VolSlideMusic.value;

        foreach (AudioSource source in audioSourcesMusic)
        {
            source.volume = Volume;
        }
    }
}
