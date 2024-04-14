using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManagers : MonoBehaviour
{
    public static GameplayManagers Instance;
    [SerializeField] private TrashHandleScript _trashHandler;
    [SerializeField] private EventManager _eventManager;

    private void Awake()
    {
        Instance = this;
    }

    public EventManager GetEventManager()
    {
        return _eventManager;
    }

    public TrashHandleScript GetTrashHandler()
    {
        return _trashHandler;
    }
}
