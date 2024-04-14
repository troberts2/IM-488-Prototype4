using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnvironmentButtons : MonoBehaviour, IClickable
{
    [SerializeField] private UnityEvent _onClickFunction;

    public void OnPlayerClick()
    {
        Debug.Log("Clicked");
        _onClickFunction?.Invoke();
    }

    public void RecycleTrash()
    {
        Debug.Log("Recycle");
    }

    public void DiscardTrash()
    {
        Debug.Log("Discard");
    }

    public void CutTrash()
    {
        Debug.Log("Cut");
    }

    public void WashTrash()
    {
        Debug.Log("Wash");
    }

    public void MeltTrash()
    {
        Debug.Log("Melt");
    }
}
