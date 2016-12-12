using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController : MonoBehaviour {

    public Camera BookCamera, FpsCamera;
    public GameObject MainControlBook, ErrorBook, PropagandaBook;
    
	// Use this for initialization
	void Start () {
		
	}

    public void DisplayBook(BookDisplay.BookType bt)
    {
        BookCamera.enabled = true;
        FpsCamera.enabled = false;
        switch (bt)
        {
            case (BookDisplay.BookType.MainControl):
                MainControlBook.SetActive(true);
                ErrorBook.SetActive(false);
                PropagandaBook.SetActive(false);
                break;
            case (BookDisplay.BookType.ErrorStatus):
                MainControlBook.SetActive(false);
                ErrorBook.SetActive(true);
                PropagandaBook.SetActive(false);
                break;
            case (BookDisplay.BookType.Propaganda):
                MainControlBook.SetActive(false);
                ErrorBook.SetActive(false);
                PropagandaBook.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            BookCamera.enabled = false;
            FpsCamera.enabled = true;
        }
	}
}
