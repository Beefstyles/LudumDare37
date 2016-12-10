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
    private bool verbSelected;
    private bool nounSelected;
    private int numberEntered;
    public TextUpdate UpdatedText;
    private bool firstVerbToBeEntered = true, firstNounToBeEntered = true;
    private int firstVerbNumber = 0, secondVerbNumber = 0;
    private int firstNounNumber = 0, secondNounNumber = 0;

    // Use this for initialization
    void Start ()
    {
        UpdatedText.Verb_Entry_1.text = firstVerbNumber.ToString();
        UpdatedText.Verb_Entry_2.text = numberEntered.ToString();
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
                if (!verbSelected)
                {
                    verbSelected = true;
                    nounSelected = false;
                }
                break;
            case (PossibleActions.Noun):
                if (!nounSelected)
                {
                    nounSelected = true;
                    verbSelected = false;
                }
                break;
            case (PossibleActions.Clear):
                break;
            case (PossibleActions.Execute):
                break;

        }
    }

    private void NumberHandler(int numberEntered)
    {
        if (verbSelected)
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

        if (nounSelected)
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


}


