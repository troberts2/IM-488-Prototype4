using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookFunctionality : MonoBehaviour, IClickable
{
    [SerializeField] private List<GameObject> _leftPages;
    [SerializeField] private List<GameObject> _rightPages;
    [SerializeField] private List<GameObject> _arrows;
    [SerializeField] private Animator _bookAnimator;

    private int _currentPage = 0;
    private bool _bookOpen = false;

    private const string _openAnimBool = "InteractBook";

    public void BookInteract()
    {
        _bookOpen = !_bookOpen;
        _bookAnimator.SetBool(_openAnimBool, _bookOpen);
        //ShowArrows(_bookOpen);
    }

    public void ShowArrows()
    {
        VisualizeArrows(true);
    }

    public void HideArrows()
    {
        VisualizeArrows(false);
    }

    private void VisualizeArrows(bool show)
    {
        foreach(GameObject arrow in _arrows)
        {
            arrow.SetActive(show);
        }
    }
    
    public void LeftFlip()
    {
        
    }

    public void RightFlip()
    {

    }

    private void PageActive(int page, bool active)
    {
        _leftPages[page].SetActive(active);
        _rightPages[page].SetActive(active);
    }

    public void PageProgressInDirection(int dir)
    {
        PageActive(_currentPage, false);

        _currentPage += dir;

        if (_leftPages.Count-1 < _currentPage)
            _currentPage = 0;
        else if (0 > _currentPage)
            _currentPage = _leftPages.Count-1;

        PageActive(_currentPage, true);
    }

    public void OnPlayerClick()
    {
        BookInteract();
    }
}
