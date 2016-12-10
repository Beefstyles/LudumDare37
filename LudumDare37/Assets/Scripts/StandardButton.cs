using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardButton : MonoBehaviour {

    public bool ButtonPressed { get; set; }
    public Material ButtonOnMat, ButtonOffMat;
    private bool buttonOn;
    private MeshRenderer gameObjMesh;

	// Use this for initialization
	void Start ()
    {
        gameObjMesh = GetComponent<MeshRenderer>();
        gameObjMesh.material = ButtonOffMat;
        buttonOn = false;
        ButtonPressed = false;
		
	}

	void Update ()
    {
        if (ButtonPressed)
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
	}
}
