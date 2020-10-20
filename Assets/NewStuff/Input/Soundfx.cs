﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//playing sounds when buttons are selected through keys uses ISelectHandler
public class Soundfx : MonoBehaviour, ISelectHandler
{


    [SerializeField]
    private AudioSource ClickfxAudio;
    [SerializeField]
    private AudioSource SwitchfxAudio;


    public AudioMixer mixerAmbience;
    [SerializeField]
    public Slider sliderAmbience;

    //when the object this script is on is selected...
    public void OnSelect(BaseEventData eventData)
    {
        //play this audio
        ClickfxAudio.Play();
    }
    //this function plays an audio. 
    public void OnClick()
    {
        SwitchfxAudio.Play();
    }

    public void SetLevel(float sliderValue)
    {
        mixerAmbience.SetFloat("AmbienceVol", Mathf.Log10(sliderValue) * 20);
        //saves the sliderValue in playerprefs as "AmbienceVolume".
        PlayerPrefs.SetFloat("AmbienceVolume", sliderValue);
    }



    // Start is called before the first frame update
    void Start()
    {
        //retrieves the playerpref "AmbienceVolume" and sets the value of the slider to that.
        sliderAmbience.value = PlayerPrefs.GetFloat("AmbienceVolume", 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
