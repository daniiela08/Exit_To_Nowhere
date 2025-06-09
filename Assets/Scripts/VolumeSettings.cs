using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    void Start()
    {                   //si existe el playerpref
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        //para convertir el slider en logaritmico. Es decir, coger del 0,0001 pasando por los decimales hasta 1.
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        myMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
        //guardar el volumen
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
    }
    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        //para convertir el slider en logaritmico. Es decir, coger del 0,0001 pasando por los decimales hasta 1.
        volume = Mathf.Clamp(volume, 0.0001f, 1f);
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        //guardar el volumen
        PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value);
    }
    private void LoadVolume()
    {
        //guardar el progreso del slider y decirle q era su volumen.
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");

        SetMusicVolume();
        SetSFXVolume();
    }
}
