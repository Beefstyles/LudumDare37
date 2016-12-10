using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PossibleActions
{
    One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Verb, Noun, Clear, Execute
};

public enum ButtonType
{
    Toggle, OnePress
};

public class ButtonCharacteristics : MonoBehaviour {

    public PossibleActions PossibleActions;
    public ButtonType ButtonType;
}
