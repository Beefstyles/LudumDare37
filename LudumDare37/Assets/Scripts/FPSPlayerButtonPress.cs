using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSPlayerButtonPress : MonoBehaviour {

    private RaycastHit hit;
    private Camera fpsCamera;
    StandardButton sb;


    void Start()
    {
        fpsCamera = GetComponentInChildren<Camera>();
    }
	void Update ()
    {
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, 100F))
        {
            if (Input.GetButtonDown("Fire1") && hit.transform.gameObject.tag=="Clickable")
            {
                sb = hit.transform.gameObject.GetComponent<StandardButton>();
                sb.ButtonPressed = true;
            }
        }
        
		
	}
}
