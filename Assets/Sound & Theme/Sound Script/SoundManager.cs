using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [SerializeField] AudioMixer mixer;

    public const string BGM_Key = "BGMVolume";                                 
    public const string SFX_Key = "SFXVolume";

    void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    void LoadVolume()            // volume Setting saved in AudioManger.cs
    {
        float musicVolume = PlayerPrefs.GetFloat(BGM_Key, 1f);                            // reloadar sparade settings
        float SoundEffectVolume = PlayerPrefs.GetFloat(SFX_Key, 1f);

        mixer.SetFloat(AudioManager.BGM_Sound, Mathf.Log10(musicVolume) * 20);            // s�tter volume till max n�r den laddar om inte n�gon �ndring har s�ts
        mixer.SetFloat(AudioManager.SFX_Sound, Mathf.Log10(SoundEffectVolume) * 20);
    }
}
