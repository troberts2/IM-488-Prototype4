using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingDecisionManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        GameplayManagers.Instance.GetEventManager().GetSortDecisionEvent().AddListener(PlayerSortActionDecision);
    }

    private void PlayerSortActionDecision(bool recycled)
    {
        if (ObjectShouldBeRecycled() == recycled)
            GameplayManagers.Instance.GetEventManager().InvokeSortCorrectness(true);
        else
            GameplayManagers.Instance.GetEventManager().InvokeSortCorrectness(false);
    }


    private bool ObjectShouldBeRecycled()
    {
        //This is incomplete, I just set up the framework
        //Return true if the object should be recycled
        //Return false if the object should be discarded
        //Thanks <3
        return false;
    }
}
