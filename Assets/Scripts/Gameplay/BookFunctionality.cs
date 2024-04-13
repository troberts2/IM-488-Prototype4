using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFunctionality : MonoBehaviour
{
    [SerializeField] private Animator _bookAnimator;

    private bool _bookOpen = false;

    private const string _openAnimBool = "InteractBook";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
            BookInteract();
    }

    public void BookInteract()
    {
        _bookOpen = !_bookOpen;
        _bookAnimator.SetBool(_openAnimBool, _bookOpen);
    }
    
}
