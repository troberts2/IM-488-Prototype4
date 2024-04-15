using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clipboard : MonoBehaviour, IClickable
{
    [Header("Clipboard UI")]
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descText;
    [SerializeField] private TMP_Text _destinationText;
    [Space]
    [SerializeField] private Animator _bookAnimator;
    private bool _boardUp = false;

    private const string _pickUpAnimBool = "InteractBoard";
    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        GameplayManagers.Instance.GetEventManager().GetTrashAtEndEvent().AddListener(UpdateUIOnClipboard);
    }

    private void UpdateUIOnClipboard()
    {

    }

    #region PlayerInteractions
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
    #endregion
}
