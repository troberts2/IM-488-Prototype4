
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{
   

    public List<GameObject> listOfTrashTypes = new List<GameObject>();

    public bool isReadyForNextItem;
    private void Start()
    {
        isReadyForNextItem = true;
    }

    private void Update()
    {
        if (isReadyForNextItem) 
        {
            SpawnTrash(Random.Range(0,listOfTrashTypes.Count));
            isReadyForNextItem = false;
        }

        print(isReadyForNextItem);
    }

    void SpawnTrash(int index)
    {
        Instantiate(listOfTrashTypes[index], transform.position, Quaternion.identity);
    }

}
