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
                ActionHandler(pa);
                break;
            case PossibleActions.Noun:
                ActionHandler(pa);
                break;
            case PossibleActions.Clear:
                ActionHandler(pa);
                break;
            case PossibleActions.Execute:
                ActionHandler(pa);
                break;
            default:
                ParseNumberInput(pa);
                break;
        }
    }

    private void ParseNumberInput(PossibleActions pa)
    {
        switch (pa)
        {
            case (PossibleActions.One):
                numberEntered = 1;
                break;
            case (PossibleActions.Two):
                numberEntered = 2;
                break;
            case (PossibleActions.Three):
                numberEntered = 3;
                break;
            case (PossibleActions.Four):
                numberEntered = 4;
                break;
            case (PossibleActions.Five):
                numberEntered = 5;
                break;
            case (PossibleActions.Six):
                numberEntered = 6;
                break;
            case (PossibleActions.Seven):
                numberEntered = 7;
                break;
            case (PossibleActions.Eight):
                numberEntered = 8;
                break;
            case (PossibleActions.Nine):
                numberEntered = 9;
                break;
        }
        NumberHandler(numberEntered);
    }

    private void ActionHandler(PossibleActions pa)
    {
        switch (pa)
        {
            case (PossibleActions.Verb):
                break;
            case (PossibleActions.Noun):
                break;
            case (PossibleActions.Clear):
                break;
            case (PossibleActions.Execute):
                break;

        }
    }

    private void NumberHandler(int numberEntered)
    {

    }
}


