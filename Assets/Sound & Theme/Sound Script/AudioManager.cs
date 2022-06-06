using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider bgmSlider;
    [SerializeField] Slider SFXSlider;

    public const string BGM_Sound = "BGMVolume";
    public const string SFX_Sound = "SFXVolume";

    void Awake()
    {
        bgmSlider.onValueChanged.AddListener(SetMusicVolume);                          // addar listener för att bestäma musik
        SFXSlider.onValueChanged.AddListener(SetSfxVolume);
    }

    void Start()
    {
        bgmSlider.value = PlayerPrefs.GetFloat(SoundManager.BGM_Key, 1f);               // Audio inställing i Start
        SFXSlider.value = PlayerPrefs.GetFloat(SoundManager.SFX_Key, 1f);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(SoundManager.BGM_Key, bgmSlider.value);
        PlayerPrefs.SetFloat(SoundManager.SFX_Key, SFXSlider.value);
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(BGM_Sound, Mathf.Log10(value) * 20);                      // Musik inställning
    }
    void SetSfxVolume(float value)
    {
        mixer.SetFloat(SFX_Sound, Mathf.Log10(value) * 20);
    }
}
