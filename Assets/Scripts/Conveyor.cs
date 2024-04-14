using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Conveyor : MonoBehaviour
{
    [SerializeField] Transform targetPos;
    [SerializeField] float speed;

    private List<GameObject> _trashOnConveyor = new List<GameObject>();
     public GameObject currentTrash;
    private bool isThereTrashOnConveyor = false;

    [SerializeField] GameObject trashHandleButtons;

    private void Update()
    {
        if (isThereTrashOnConveyor)
        {
            
            if (currentTrash != null && currentTrash.transform.position != targetPos.position)
            {
                currentTrash.transform.position = Vector3.MoveTowards(currentTrash.transform.position, targetPos.position, speed * Time.deltaTime );
                trashHandleButtons.SetActive(false);
            }

            if (currentTrash != null && currentTrash.transform.position == targetPos.position)
            {
                //enable trash handle buttons
                trashHandleButtons.SetActive(true);

            }
        }

       
      
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Trash")
        {
            currentTrash = collision.gameObject;
            currentTrash.GetComponent<Rigidbody>().useGravity = false;
            isThereTrashOnConveyor = true;
        }
    }

    
    void OnCollisionExit(Collision collision)
    {
        // was picked up or something
        if (collision.gameObject == currentTrash)
        {
            currentTrash.GetComponent<Rigidbody>().useGravity = true;
            isThereTrashOnConveyor = false;
            currentTrash = null;
            gameObject.GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;
            print("exit");

        }
    }
}
