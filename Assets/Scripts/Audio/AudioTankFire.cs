using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioTankFire : MonoBehaviour
{
    public AudioClip fire;
    public AudioSource audioSource;

    public void PlayFire()
    {
        audioSource.PlayOneShot(fire);
    }

}
