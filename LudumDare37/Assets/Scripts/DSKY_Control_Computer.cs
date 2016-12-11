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
    public Light Light1, Light2, Light3, Light4;
    private int numberEntered;
    public TextUpdate UpdatedText;
    private bool firstVerbToBeEntered = true, firstNounToBeEntered = true;
    private int firstVerbNumber = 0, secondVerbNumber = 0;
    private int firstNounNumber = 0, secondNounNumber = 0;
    private bool isRadioOn = false;

    // Use this for initialization
    void Start ()
    {
        VerbSelected = false;
        NounSelected = false;
        UpdateAllVerbNounTexts();
        ErrorCodeHandler("E7702");
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
            case (PossibleActions.Zero):
                numberEntered = 0;
                break;
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
                ExecuteActions(firstVerbNumber, secondVerbNumber, firstNounNumber, secondNounNumber);
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
                updateNoun2Text(secondNounNumber);
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
        string combinedNoun = firstNoun.ToString() + secondNoun.ToString();

        Debug.Log("combined verb is " + combinedVerb + " combined noun is " + combinedNoun);
        switch (combinedVerb)
        {
            case ("00"): //Engines
                switch (combinedNoun)
                {
                    case ("32"): // Off
                        ControlEngines(false);
                        break;
                    case ("54"): // On
                        ControlEngines(true);
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
                break;
            case ("11"): //Lights
                Debug.Log("Lights!");
                switch (combinedNoun)
                {
                    case ("00"): // Off
                        Debug.Log("Off!");
                        ControlLights("Off");
                        break;
                    case ("44"): // Green
                        Debug.Log("Green!");
                        ControlLights("Green");
                        break;
                    case ("67"): // Red
                        ControlLights("Red");
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
                break;
            case ("22"): //Radio
                switch (combinedNoun)
                {
                    case ("15"): // Off
                        ControlRadio(false);
                        break;
                    case ("25"): // On
                        ControlRadio(true);
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
                break;
            case ("33"): //Beacon
                switch (combinedNoun)
                {
                    case ("22"): // Deploy
                        ControlBeacon("Deploy");
                        break;
                    case ("47"): // On
                        ControlBeacon("On");
                        break;
                    case ("68"): // Off
                        ControlBeacon("Off");
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
                break;
            case ("44"): //Gravity
                switch (combinedNoun)
                {
                    case ("44"): // On
                        ControlGravity(true);
                        break;
                    case ("54"): // Off
                        ControlGravity(false);
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
                break;
            case ("55"): //Orientation
                switch (combinedNoun)
                {
                    case ("12"): // Flip
                        FlipShip();
                        break;
                }
                break;
            case ("66"): //Sensors
                switch (combinedNoun)
                {
                    case ("12"): // Active Scanning On
                        ControlSensors(true);
                        break;
                    case ("22"): // Active Scanning Off
                        ControlSensors(false);
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
                break;
            case ("77"): //Life support
                switch (combinedNoun)
                {
                    case ("14"): // O2 On
                        LifeSupportControl("O2 On");
                        break;
                    case ("24"): // O2 Off
                        LifeSupportControl("O2 Off");
                        break;
                    case ("56"): // CO2 Scrubber On
                        LifeSupportControl("CO2 Scrub On");
                        break;
                    case ("66"): // CO2 Scrubber off
                        LifeSupportControl("CO2 Scrub Off");
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
                break;
            case ("88"): //Personnel supports
                switch (combinedNoun)
                {
                    case ("77"): // Restraints On
                        RestraintsControl(true);
                        break;
                    case ("88"): // Restraints Off
                        RestraintsControl(false);
                        break;
                    case ("99"): // Deep Freeze On
                        DeepFreezeOn();
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
                break;
            case ("99"):
                switch (combinedNoun)
                {
                    case ("44"):
                        break;
                    case ("56"):
                        break;
                    default:
                        //Invalid verb
                        ErrorCodeHandler("E1976");
                        break;
                }
            break;
            default:
                //Invalid verb
                ErrorCodeHandler("E1908");
                break;
        }
    }

    private void ControlEngines(bool engineOn)
    {

    }

    private void ControlLights(string action)
    {
        //Light Light1, Light2, Light3, Light4;
        switch (action)
        {
            //Off, Green, Red
            case ("Off"):
                Light1.color = Color.black;
                Light2.color = Color.black;
                Light3.color = Color.black;
                Light4.color = Color.black;
                ErrorCodeHandler("S1156");
                break;
            case ("Green"):
                Light1.color = Color.green;
                Light2.color = Color.green;
                Light3.color = Color.green;
                Light4.color = Color.green;
                ErrorCodeHandler("S1196");
                break;
            case ("Red"):
                Light1.color = Color.red;
                Light2.color = Color.red;
                Light3.color = Color.red;
                Light4.color = Color.red;
                ErrorCodeHandler("S1183");
                break;
            

        }
    }

    private void ControlRadio(bool radioOn)
    {
        if (radioOn)
        {
            if (!isRadioOn)
            {
                isRadioOn = true;
            }
        }
    }

    private void ControlBeacon(string action)
    {

    }

    private void ControlGravity(bool gravityOn)
    {

    }

    private void FlipShip()
    {

    }

    private void ControlSensors(bool sensorsOn)
    {

    }

    private void LifeSupportControl(string action)
    {

    }

    private void RestraintsControl(bool restraintsOn)
    {

    }

    private void DeepFreezeOn()
    {

    }

    private void ErrorCodeHandler(string errorCode)
    {
        UpdatedText.StatusCode.text = errorCode;
    }
}


