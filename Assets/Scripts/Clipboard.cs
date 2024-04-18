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
    //[SerializeField] private TMP_Text _destinationText;
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
        GameplayManagers.Instance.GetEventManager().GetTrashSpawnedEvent().AddListener(UpdateUIOnClipboard);
        //GameplayManagers.Instance.GetEventManager().GetTrashAtEndEvent().AddListener(UpdateUIOnClipboard);
    }

    private void UpdateUIOnClipboard()
    {
        Invoke(nameof(Delay), 1);
        
    }

    private void Delay()
    {
        //TrashObj currentTrash = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.GetComponent<LinkToScriptableObject>()._object;
        TrashObj currentTrash = FindObjectOfType<LinkToScriptableObject>()._object;

        Debug.Log("update UI" + currentTrash.objName);

        _nameText.text = currentTrash.name;

        _descText.text = currentTrash.description;
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
