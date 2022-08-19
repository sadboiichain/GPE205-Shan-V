using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioButton : MonoBehaviour
{
    public AudioClip button;
    public AudioSource audioSource;

    public void PlayButton()
    {
        audioSource.PlayOneShot(button);
    }
}
