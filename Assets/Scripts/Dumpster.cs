using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dumpster : MonoBehaviour
{
    [SerializeField] private List<GameObject> _models;
    private int _modelPos;

    public void SubscribeToEvents()
    {
        GameplayManagers.Instance.GetEventManager().GetSortCorrectnessEvent().AddListener(IncrementModels);
    }

    private void IncrementModels(bool correct)
    {
        if(!correct && _models[_modelPos +1] != null)
        {
            _models[_modelPos].SetActive(false);
            _modelPos++;
            _models[_modelPos].SetActive(true);
        }    
    }

}
