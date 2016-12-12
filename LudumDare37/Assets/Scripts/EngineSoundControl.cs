using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSoundControl : MonoBehaviour {

    private bool engineOn = false;
    public AudioSource engineSounds;

    void Start()
    {
        engineOn = false;
        engineSounds.mute = true;
    }
    public void EngineOn()
    {
        if (!engineOn)
        {
            engineOn = true;
            engineSounds.mute = false;
        }
    }

    public void EngineOff()
    {
        if (engineOn)
        {
            engineOn = false;
            engineSounds.mute = true;
        }
    }
}
