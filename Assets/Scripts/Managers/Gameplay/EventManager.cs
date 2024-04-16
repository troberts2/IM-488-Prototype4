using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private UnityEvent _trashSpawned = new UnityEvent();
    private UnityEvent _trashAtEndOfConveyor = new UnityEvent();

    private UnityEvent _recycleSort = new UnityEvent();
    private UnityEvent _discardSort = new UnityEvent();

    private UnityEvent _correctSort = new UnityEvent();
    private UnityEvent _incorrectSort = new UnityEvent();

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

    public void InvokeRecycleSort()
    {
        _recycleSort?.Invoke();
    }

    public void InvokeDiscardSort()
    {
        _discardSort?.Invoke();
    }

    public void InvokeCorrectSort()
    {
        _correctSort?.Invoke();
    }

    public void InvokeIncorrectSort()
    {
        _incorrectSort?.Invoke();
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

    public UnityEvent GetRecycleSortEvent()
    {
        return _recycleSort;
    }

    public UnityEvent GetDiscardSort()
    {
        return _discardSort;
    }

    public UnityEvent GetCorrectSortEvent()
    {
        return _correctSort;
    }

    public UnityEvent GetIncorrectSortEvent()
    {
        return _incorrectSort;
    }
    #endregion
}
