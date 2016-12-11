using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterControllerScript : MonoBehaviour {

    public bool PlayerMovementActive { get; set; }
    public Camera EndGameCamera;
    DSKY_Control_Computer dskyControl;
    public Text KillString;
	
	void Start ()
    {
        dskyControl = FindObjectOfType<DSKY_Control_Computer>();
        EndGameCamera.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void EndGame(string killName)
    {
        EndGameCamera.enabled = true;
        KillString.text = killName;
    }
}
