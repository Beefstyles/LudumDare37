using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class TextUpdate
{
    public TextMesh Verb_Entry_1, Verb_Entry_2, Noun_Entry_1, Noun_Entry_2;
    public TextMesh StatusCode;
}
public class DSKY_Control_Computer : MonoBehaviour {

    //One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Verb, Noun, Clear, Execute
    public bool VerbSelected { get; set; }
    public bool NounSelected { get; set; }
    private int numberEntered;
    public TextUpdate UpdatedText;
    private bool firstVerbToBeEntered = true, firstNounToBeEntered = true;
    private int firstVerbNumber = 0, secondVerbNumber = 0;
    private int firstNounNumber = 0, secondNounNumber = 0;

    // Use this for initialization
    void Start ()
    {
        VerbSelected = false;
        NounSelected = false;
        UpdateAllVerbNounTexts();
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
                if (!VerbSelected)
                {
                    VerbSelected = true;
                    NounSelected = false;
                }
                break;
            case (PossibleActions.Noun):
                if (!NounSelected)
                {
                    NounSelected = true;
                    VerbSelected = false;
                }
                break;
            case (PossibleActions.Clear):
                ClearText();
                break;
            case (PossibleActions.Execute):
                break;

        }
    }

    private void NumberHandler(int numberEntered)
    {
        if (VerbSelected)
        {
            if (firstVerbToBeEntered)
            {       
                firstVerbNumber = numberEntered;
                updateVerb1Text(firstVerbNumber);
                firstVerbToBeEntered = false;
            }
            else
            {
                secondVerbNumber = numberEntered;
                updateVerb2Text(secondVerbNumber);
                firstVerbToBeEntered = true;
            }
        }

        if (NounSelected)
        {
            if (firstNounToBeEntered)
            {
                firstNounNumber = numberEntered;
                updateNoun1Text(firstNounNumber);
                firstNounToBeEntered = false;
            }
            else
            {
                secondNounNumber = numberEntered;
                updateNoun2Text(secondVerbNumber);
                firstNounToBeEntered = true;
            }
        }
    }

    private void ClearText()
    {
        firstVerbNumber = 0;
        secondVerbNumber = 0;
        firstNounNumber = 0;
        secondNounNumber = 0;
        UpdateAllVerbNounTexts();
    }

    private void UpdateAllVerbNounTexts()
    {
        updateVerb1Text(firstVerbNumber);
        updateVerb2Text(secondVerbNumber);
        updateNoun1Text(firstNounNumber);
        updateNoun2Text(secondNounNumber);
    }

    private void updateVerb1Text(int number)
    {
        UpdatedText.Verb_Entry_1.text = number.ToString();
    }

    private void updateVerb2Text(int number)
    {
        UpdatedText.Verb_Entry_2.text = number.ToString();
    }

    private void updateNoun1Text(int number)
    {
        UpdatedText.Noun_Entry_1.text = number.ToString();
    }

    private void updateNoun2Text(int number)
    {
        UpdatedText.Noun_Entry_2.text = number.ToString();
    }


    private void ExecuteActions(int firstVerb, int secondVerb, int firstNoun, int secondNoun)
    {
        string combinedVerb = firstVerb.ToString() + secondVerb.ToString();
        string combinedNoun = firstVerb.ToString() + secondVerb.ToString();

        switch (combinedVerb)
        {

        }
    }
}


