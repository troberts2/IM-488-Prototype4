using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookArrow : MonoBehaviour, IClickable
{
    [SerializeField] private BookFunctionality _associatedBook;
    [SerializeField] private int _pageDirection;
    public void OnPlayerClick()
    {
        _associatedBook.PageProgressInDirection(_pageDirection);
    }
}
