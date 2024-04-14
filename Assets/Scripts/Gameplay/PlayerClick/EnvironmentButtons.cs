using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnvironmentButtons : MonoBehaviour, IClickable
{
    [SerializeField] private UnityEvent _onClickFunction;

    public void OnPlayerClick()
    {
        _onClickFunction?.Invoke();
    }
}
