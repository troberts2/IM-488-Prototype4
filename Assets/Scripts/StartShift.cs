using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartShift : MonoBehaviour
{
    ScoreManager scoreManager;
    SortingDecisionManager sortingDecisionManager;

    [SerializeField] GameObject button;
    [SerializeField] TMP_Text shiftText;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        sortingDecisionManager = GameObject.FindGameObjectWithTag("SortingDecitionManager").GetComponent<SortingDecisionManager>();
    }
    public void StartMyShift()
    {
        //allow points to be incremented or decremented
        scoreManager.SubscribeToEvents();
        sortingDecisionManager.SubscribeToEvents();

        button.GetComponent<MeshRenderer>().material.color = Color.red;
        shiftText.text = "On Shift";
    }
}
