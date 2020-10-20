﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//playing sounds when buttons are selected through keys uses ISelectHandler
public class Soundfx : MonoBehaviour, ISelectHandler
{


    [SerializeField]
    private AudioSource ClickfxAudio;
    [SerializeField]
    private AudioSource SwitchfxAudio;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
