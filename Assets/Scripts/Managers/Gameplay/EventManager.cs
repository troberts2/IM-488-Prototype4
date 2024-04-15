using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    private UnityEvent _trashSpawned = new UnityEvent();
    private UnityEvent _trashAtEndOfConveyor = new UnityEvent();

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

    public UnityEvent GetTrashSpawnedEvent()
    {
        return _trashSpawned;
    }

    public UnityEvent GetTrashAtEndEvent()
    {
        return _trashAtEndOfConveyor;
    }
}
