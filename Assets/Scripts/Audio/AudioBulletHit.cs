using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioBulletHit : MonoBehaviour
{
    public AudioClip hit;
    public AudioSource audioSource;

    public void PlayHit()
    {
        audioSource.PlayOneShot(hit);
    }
}
