using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirConControl : MonoBehaviour {

    private bool airConOn = false;
    public AudioSource airConSounds;

    void Start()
    {
        airConOn = false;
        airConSounds.mute = true;
    }
    public void ACOff()
    {
        if (!airConOn)
        {
            airConOn = true;
            airConSounds.mute = false;
        }
    }

    public void ACOn()
    {
        if (airConOn)
        {
            airConOn = false;
            airConSounds.mute = true;
        }
    }
}
