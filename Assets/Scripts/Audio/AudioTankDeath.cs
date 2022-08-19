using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioTankDeath : MonoBehaviour
{
    public AudioClip death;
    public AudioSource audioSource;

    public void Playdeath()
    {
        audioSource.PlayOneShot(death);
    }
}
