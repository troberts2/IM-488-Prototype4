using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashHandleScript : MonoBehaviour
{
    [SerializeField] Button recycle;
    [SerializeField] Button discard;

    private void OnEnable()
    {
        recycle.enabled = true;
        discard.enabled = true;
    }

    public void CutTrash()
    {

    }

    public void WashTrash()
    {

    }

    public void MeltTrash()
    {

    }

    public void DiscardTrash()
    {
        discard.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash);
        GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;
        print("help");
    }

    public void RecycleTrash()
    {
        recycle.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash);
        GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;
        
        print("help");
    }

    
}
