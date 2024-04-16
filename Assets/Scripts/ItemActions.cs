using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemActions : MonoBehaviour
{
    GameObject currentTrash;
    [SerializeField] private Material shinyMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    void ChemicalWashItem(){
        currentTrash.GetComponent<MeshRenderer>().material = shinyMaterial;
    }
}
