using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPickup : MonoBehaviour
{
    public AudioClip pickup;
    public AudioSource audioSource;

    public void PlayPickup()
    {
        audioSource.PlayOneShot(pickup);
    }
}
