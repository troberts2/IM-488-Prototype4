using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private UnityEvent _trashSpawned = new UnityEvent();
    private UnityEvent _trashAtEndOfConveyor = new UnityEvent();

    private UnityEvent<bool> _sortDecision = new UnityEvent<bool>();
    private UnityEvent<bool> _sortCorrectness = new UnityEvent<bool>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void InvokeTrashSpawned()
    {
        _trashSpawned?.Invoke();
    }

    public void InvokeTrashAtEnd()
    {
        _trashAtEndOfConveyor?.Invoke();
    }

    public void InvokeSortDecision(bool decision)
    {
        _sortDecision.Invoke(decision);
    }

    public void InvokeSortCorrectness(bool correct)
    {
        _sortCorrectness.Invoke(correct);
    }


    #region Getters and Setters
    public UnityEvent GetTrashSpawnedEvent()
    {
        return _trashSpawned;
    }

    public UnityEvent GetTrashAtEndEvent()
    {
        return _trashAtEndOfConveyor;
    }

    public UnityEvent<bool> GetSortDecisionEvent()
    {
        Debug.Log("getsortEvent");
        return _sortDecision;
    }

    public UnityEvent<bool> GetSortCorrectnessEvent()
    {
        return _sortCorrectness;
    }


    
    #endregion
}
