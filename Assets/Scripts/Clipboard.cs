using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Clipboard : MonoBehaviour, IClickable
{
    [Header("Clipboard UI")]
    [SerializeField] private TMP_Text _nameText;
    [SerializeField] private TMP_Text _descText_Name;
    [SerializeField] private TMP_Text _descText_Material;
    [SerializeField] private TMP_Text _descText_Report;

    private string Report;
    private int daysToTransport;
    private string objectCondition;
    private string objectDestination;
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

        _descText_Name.text = currentTrash.name;

        daysToTransport = Random.Range(1, 14);

        int randCondition = Random.Range(0,7);

        switch (randCondition)
        {
            case 0:
                objectCondition = "good";
                break;
            case 1:
                objectCondition = "bad";
                break;
            case 2:
                objectCondition = "good";
                break;
            case 3:
                objectCondition = "bad";
                break;
            case 4:
                objectCondition = "good";
                break;
            case 5:
                objectCondition = "bad";
                break;
            case 6:
                objectCondition = "good";
                break;
            case 7:
                objectCondition = "bad";
                break;
            default:
                print("unkown condition");
                break;
        }
        
        objectDestination = "Suburbia";
        Report = "The object took " + daysToTransport + " days to transport and was found in " + objectCondition + " condition.";

        _descText_Report.text = Report;
        switch (currentTrash.materialName)
        {
            case "wood":
                _descText_Material.text = "wood";
                _descText_Material.color = Color.yellow;
                break;
            case "paper":
                _descText_Material.text = "paper";
                _descText_Material.color = Color.green;
                break;
            case "aluminum":
                _descText_Material.text = "aluminum";
                _descText_Material.color = Color.yellow;
                break;
            case "iron":
                _descText_Material.text = "iron";
                _descText_Material.color = Color.yellow;
                break;
            case "copper":
                _descText_Material.text = "copper";
                _descText_Material.color = Color.yellow;
                break;
            case "uranium":
                _descText_Material.text = "uranium";
                _descText_Material.color = Color.red;
                break;
            case "PET plastic":
                _descText_Material.text = "PET plastic";
                _descText_Material.color = Color.yellow;
                break;
            case "HDPE plastic":
                _descText_Material.text = "HDPE plastic";
                _descText_Material.color = Color.yellow;
                break;
            case "PVC plastic":
                _descText_Material.text = "PVC plastic";
                _descText_Material.color = Color.red;
                break;
            case "PS plastic":
                _descText_Material.text = "PS Plastic";
                _descText_Material.color = Color.red;
                break;
            default:
                break;
        }

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
