using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDisplay : MonoBehaviour {

    public enum BookType
    {
        MainControl, ErrorStatus, Propaganda
    };

    public BookType bookType;
    BookController bc;

    void Start()
    {
        bc = FindObjectOfType<BookController>();
    }
	public void DisplayBookText()
    {
        bc.DisplayBook(bookType);
    }
}
