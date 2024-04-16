using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingDecisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void SubscribeToEvents()
    {
        GameplayManagers.Instance.GetEventManager().GetTrashAtEndEvent().AddListener(UpdateUIOnClipboard);
    }

    private void CheckSortCorrectness()
    {

    }
}
