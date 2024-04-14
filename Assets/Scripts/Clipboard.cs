using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clipboard : MonoBehaviour, IClickable
{
    [SerializeField] private Animator _bookAnimator;
    private bool _boardUp = false;

    private const string _pickUpAnimBool = "InteractBoard";
    // Start is called before the first frame update
    void Start()
    {

    }

    public void OnPlayerClick()
    {
        BoardInteract();
    }

    public void BoardInteract()
    {
        _boardUp = !_boardUp;
        _bookAnimator.SetBool(_pickUpAnimBool, _boardUp);
        //ShowArrows(_bookOpen);
    }
}
