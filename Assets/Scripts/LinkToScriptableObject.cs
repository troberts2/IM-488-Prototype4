using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkToScriptableObject : MonoBehaviour
{
    public TrashObj _object;


    private void Start()
    {
        _object = new TrashObj();
        _object.CreateTrash(1);
        _object.name = gameObject.name;
        _object.description = "a " + name.Remove(name.Length - 7) + " made of " + _object.materialName;
        print(_object.description);
        
    }
}
