using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManagers : MonoBehaviour
{
    public static GameplayManagers Instance;
    [SerializeField] private EventManager _eventManager;

    private void Start()
    {
        Instance = this;
    }

    public EventManager GetEventManager()
    {
        return _eventManager;
    }
}
