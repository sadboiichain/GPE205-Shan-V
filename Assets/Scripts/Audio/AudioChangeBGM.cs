using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioChangeBGM : MonoBehaviour
{
    public AudioSource Menu;
    public AudioSource Game;

    public void PlayMenu()
    {
        Game.Stop();
        Menu.Play();
    }

    public void PlayGame()
    {
        Menu.Stop();
        Game.Play();
    }
}
