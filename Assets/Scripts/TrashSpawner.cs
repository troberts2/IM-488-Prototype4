
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
   

    public List<GameObject> listOfTrashTypes = new List<GameObject>();
    private TrashHandleScript trashHandleScript;
    float i = 0;

    public bool isReadyForNextItem;
    private void Start()
    {
        isReadyForNextItem = true;
        trashHandleScript = FindObjectOfType<TrashHandleScript>();
    }

    private void SubscribeToEvents()
    {
        GameplayManagers.Instance.GetEventManager().GetSortCorrectnessEvent().AddListener(ReadyForNext);
    }

    private void Update()
    {
        i += Time.deltaTime;
        if (isReadyForNextItem && i > 1) 
        {
            SpawnTrash(Random.Range(0,listOfTrashTypes.Count));
            isReadyForNextItem = false;
        }

    }

    void SpawnTrash(int index)
    {
        GameObject spawnedTrash = Instantiate(listOfTrashTypes[index], transform.position, Quaternion.identity);
        trashHandleScript.ogTrashColor = spawnedTrash.GetComponent<MeshRenderer>().material.color;
        GameplayManagers.Instance.GetEventManager().InvokeTrashSpawned();
    }

    public void ReadyForNext(bool none)
    {
        isReadyForNextItem = true;
    }

}
