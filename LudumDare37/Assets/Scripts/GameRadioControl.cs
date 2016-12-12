using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRadioControl : MonoBehaviour {

    private bool radioOn = false;
    public AudioSource radioMusic;

    void Start()
    {
        radioOn = false;
        radioMusic.mute = true;
    }
    public void RadioOn()
    {
        if (!radioOn)
        {
            radioOn = true;
            radioMusic.mute = false;
        }
    }

    public void RadioOff()
    {
        if (radioOn)
        {
            radioOn = false;
            radioMusic.mute = true;
        }
    }


}
