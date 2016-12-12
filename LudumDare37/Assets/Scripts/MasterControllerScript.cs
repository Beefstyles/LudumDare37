using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterControllerScript : MonoBehaviour {

    public bool PlayerMovementActive { get; set; }
    public Camera EndGameCamera;
    DSKY_Control_Computer dskyControl;
    public Text KillString;
    public Text VictoryText;
    public Canvas MainCanvas;
	
	void Start ()
    {
        dskyControl = FindObjectOfType<DSKY_Control_Computer>();
        EndGameCamera.enabled = false;
        MainCanvas.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void EndGame(string killName, string victoryText)
    {
        EndGameCamera.enabled = true;
        MainCanvas.enabled = true;
        KillString.text = killName;
    }
}
