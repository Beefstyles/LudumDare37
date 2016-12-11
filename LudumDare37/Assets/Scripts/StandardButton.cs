using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardButton : MonoBehaviour {

    public bool ButtonPressed { get; set; }
    public Material ButtonOnMat, ButtonOffMat;
    [SerializeField]
    private bool buttonOn;
    private MeshRenderer gameObjMesh;
    ButtonCharacteristics bc;
    DSKY_Control_Computer dskyControl;
    GameObject verbButton, nounButton;

	// Use this for initialization
	void Start ()
    {
        bc = GetComponent<ButtonCharacteristics>();
        
        dskyControl = FindObjectOfType<DSKY_Control_Computer>();
        gameObjMesh = GetComponent<MeshRenderer>();
        gameObjMesh.material = ButtonOffMat;
        buttonOn = false;
        ButtonPressed = false;
		
	}

	void Update ()
    {
        if (ButtonPressed)
        {
            if (bc.PossibleActions == PossibleActions.Verb || bc.PossibleActions == PossibleActions.Noun)
            {
                if (!buttonOn)
                {
                    if(bc.PossibleActions == PossibleActions.Verb)
                    {
                        if (dskyControl.NounSelected)
                        {
                            return;
                        }
                    }
                    else if (bc.PossibleActions == PossibleActions.Noun)
                    {
                        if (dskyControl.VerbSelected)
                        {
                            return;
                        }
                    }
                }
 
            }

            ActuateButton();
            if (bc.ButtonType == ButtonType.Toggle)
            {
                ButtonPressed = false;
                if (buttonOn)
                {
                    SetInactive();
                }

                else
                {
                    SetActive();
                }
            }

            if(bc.ButtonType == ButtonType.OnePress)
            {
                ButtonPressed = false;
                StartCoroutine("FlashButtonChange");
            }
        }
  
    }

    IEnumerator FlashButtonChange()
    {
        gameObjMesh.material = ButtonOnMat;
        yield return new WaitForSeconds(0.1F);
        gameObjMesh.material = ButtonOffMat;
    }

    private void ActuateButton()
    {
        dskyControl.ReceiveButtonPress(bc.PossibleActions);
    }

    public void SetInactive()
    {
        if (bc.PossibleActions == PossibleActions.Verb)
        {
            dskyControl.VerbSelected = false;
        }
        else if (bc.PossibleActions == PossibleActions.Noun)
        {
            dskyControl.NounSelected = false;
        }
        gameObjMesh.material = ButtonOffMat;
        buttonOn = false;
    }

    public void SetActive()
    {
        if (bc.PossibleActions == PossibleActions.Verb)
        {
            dskyControl.VerbSelected = true;
        }
        else if (bc.PossibleActions == PossibleActions.Noun)
        {
            dskyControl.NounSelected = true;
        }
        gameObjMesh.material = ButtonOnMat;
        buttonOn = true;
    }
}
