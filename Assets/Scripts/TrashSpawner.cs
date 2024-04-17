
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
   

    public List<GameObject> listOfTrashTypes = new List<GameObject>();
    private TrashHandleScript trashHandleScript;

    public bool isReadyForNextItem;
    private void Start()
    {
        isReadyForNextItem = true;
        trashHandleScript = FindObjectOfType<TrashHandleScript>();
    }

    private void Update()
    {
        if (isReadyForNextItem) 
        {
            SpawnTrash(Random.Range(0,listOfTrashTypes.Count));
            isReadyForNextItem = false;
        }

    }

    void SpawnTrash(int index)
    {
        GameObject spawnedTrash = Instantiate(listOfTrashTypes[index], transform.position, Quaternion.identity);
        trashHandleScript.ogTrashColor = spawnedTrash.GetComponent<MeshRenderer>().material.color;
    }

}
