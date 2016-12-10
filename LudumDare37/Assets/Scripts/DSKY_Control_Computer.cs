using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DSKY_Control_Computer : MonoBehaviour {

    //One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Verb, Noun, Clear, Execute
    public bool VerbSelected { get; set; }
    public bool NounSelected { get; set; }
    private int numberEntered;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReceiveButtonPress(PossibleActions pa)
    {
        switch (pa)
        {
            case PossibleActions.Verb:
                break;
            case PossibleActions.Noun:
                break;
            case PossibleActions.Clear:
                break;
            case PossibleActions.Execute:
                break;
            default:
                ParseNumberInput(pa);
                break;
        }
    }

    private void ParseNumberInput(PossibleActions pa)
    {
        switch (pa.ToString())
        {
            case ("One"):
                numberEntered = 1;
                break;
            case ("Two"):
                numberEntered = 2;
                break;
            case ("Three"):
                numberEntered = 3;
                break;
            case ("Four"):
                numberEntered = 4;
                break;
            case ("Five"):
                numberEntered = 5;
                break;
            case ("Six"):
                numberEntered = 6;
                break;
            case ("Seven"):
                numberEntered = 7;
                break;
            case ("Eight"):
                numberEntered = 8;
                break;
            case ("Nine"):
                numberEntered = 9;
                break;
        }
       

    }
}


