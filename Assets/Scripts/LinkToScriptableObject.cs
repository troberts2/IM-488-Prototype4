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
        print(_object.description);
    }
}
