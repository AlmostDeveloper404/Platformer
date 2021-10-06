using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject MenuButton;
    public GameObject MenuPanal;
    public AudioSource Music;

    public MonoBehaviour[] ScriptsToDisable;

    public void OpenMenu()
    {
        MenuButton.SetActive(false);
        MenuPanal.SetActive(true);
        for (int i = 0; i < ScriptsToDisable.Length; i++)
        {
            ScriptsToDisable[i].enabled = false;
        }
    }

    public void CloseMenu()
    {
        MenuButton.SetActive(true);
        MenuPanal.SetActive(false);
        for (int i = 0; i < ScriptsToDisable.Length; i++)
        {
            ScriptsToDisable[i].enabled = true;
        }
    }

    public void PlayMusic(bool value)
    {
        if (value)
        {
            Music.Play();
        }
        else
        {
            Music.Pause();
        }
    }

    public void VolumeAdjuster(float value)
    {
        AudioListener.volume = value;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
