using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardButton : MonoBehaviour {

    public bool ButtonPressed { get; set; }
    public Material ButtonOnMat, ButtonOffMat;
    private bool buttonOn;
    private MeshRenderer gameObjMesh;
    ButtonCharacteristics bc;

	// Use this for initialization
	void Start ()
    {
        bc = GetComponent<ButtonCharacteristics>();
        gameObjMesh = GetComponent<MeshRenderer>();
        gameObjMesh.material = ButtonOffMat;
        buttonOn = false;
        ButtonPressed = false;
		
	}

	void Update ()
    {
        if (ButtonPressed)
        {
            if(bc.ButtonType == ButtonType.Toggle)
            {
                ButtonPressed = false;
                if (buttonOn)
                {
                    gameObjMesh.material = ButtonOffMat;
                    buttonOn = false;
                }

                else
                {
                    gameObjMesh.material = ButtonOnMat;
                    buttonOn = true;
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
}
