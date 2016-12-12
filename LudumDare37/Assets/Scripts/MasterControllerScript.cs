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
    RestartButton rb;
    private bool gameEnded;

    void Start ()
    {
        dskyControl = FindObjectOfType<DSKY_Control_Computer>();
        rb = FindObjectOfType<RestartButton>();
        EndGameCamera.enabled = false;
        MainCanvas.enabled = false;
        gameEnded = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (gameEnded)
        {
            if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2"))
            {
                rb.RestartGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}

    public void EndGame(string killName, string victoryText)
    {
        EndGameCamera.enabled = true;
        MainCanvas.enabled = true;
        KillString.text = killName;
        VictoryText.text = victoryText;
        gameEnded = true;
    }
}
