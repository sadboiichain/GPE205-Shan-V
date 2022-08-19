using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Slider masterVolumeSlider;

    public AudioTankDeath death;
    public AudioTankFire fire;
    public AudioPickup pick;
    public AudioChangeBGM bgm;
    public AudioBulletHit hit;

    public void OnMusicVolumeChange()
    {
        //start with the slider value
        float newVol = musicVolumeSlider.value;
        if(newVol <= 0)
        {
            //if the vol is 0, set to lowest value
            newVol = -80;
        }
        else
        {
            //>0, so start with log10 value
            newVol = MathF.Log10(newVol);
            //make it from 0-20db
            newVol = newVol*20;
        }

        //set the volume to the new volume setting
        mainAudioMixer.SetFloat("MusicVolume", newVol);
    }

    public void OnSFXVolumeChange()
    {
                //start with the slider value
        float newVol = sfxVolumeSlider.value;
        if(newVol <= 0)
        {
            //if the vol is 0, set to lowest value
            newVol = -80;
        }
        else
        {
            //>0, so start with log10 value
            newVol = MathF.Log10(newVol);
            //make it from 0-20db
            newVol = newVol*20;
        }

        //set the volume to the new volume setting
        mainAudioMixer.SetFloat("SFXVolume", newVol);

    }

    public void OnMasterVolumeChange()
    {
        //start with the slider value
        float newVol = masterVolumeSlider.value;
        if(newVol <= 0)
        {
            //if the vol is 0, set to lowest value
            newVol = -80;
        }
        else
        {
            //>0, so start with log10 value
            newVol = MathF.Log10(newVol);
            //make it from 0-20db
            newVol = newVol*20;
        }

        //set the volume to the new volume setting
        mainAudioMixer.SetFloat("MasterVolume", newVol);
    }
}
