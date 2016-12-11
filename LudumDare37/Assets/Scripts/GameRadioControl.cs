using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRadioControl : MonoBehaviour {

    private bool radioOn = false;
    public AudioSource radioMusic;
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
