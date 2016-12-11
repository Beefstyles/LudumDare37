using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSPlayerButtonPress : MonoBehaviour {

    private RaycastHit hit;
    private Camera fpsCamera;
    StandardButton sb;
    public Image Crosshair;
    public Sprite ActiveCrosshair, NormalCrosshair;
    private bool ActiveCrosshairIsSet = false;
    

    void Start()
    {
        fpsCamera = GetComponentInChildren<Camera>();
        Crosshair.sprite = NormalCrosshair;
    }
	void Update ()
    {
        if (ActiveCrosshairIsSet)
        {
            Crosshair.sprite = NormalCrosshair;
            ActiveCrosshairIsSet = false;
        }
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, 100F))
        {
            if (hit.transform.gameObject.tag == "Clickable")
            {
                if (!ActiveCrosshairIsSet)
                {
                    Crosshair.sprite = ActiveCrosshair;
                    ActiveCrosshairIsSet = true;
                }
                if (Input.GetButtonDown("Fire1"))
                {
                    sb = hit.transform.gameObject.GetComponent<StandardButton>();
                    if(sb != null)
                    {
                        sb.ButtonPressed = true;
                    }

                    else
                    {
                        
                    }
                    
                }
            }
        }

		
	}
}
