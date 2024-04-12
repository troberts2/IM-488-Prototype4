using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newTrash", menuName = "Trash", order = 1)]
public class TrashObj : ScriptableObject
{

    enum material
    {
        Wood,//recyclable
        metal,//recyclable
        plastic
    }


    [Header("The name of the object")]
    [SerializeField] string name;
    [Header("The game object that will be representing the object")]
    [SerializeField] GameObject visualRepresentation;
    //the material the object is made of
    [Header("The material the object is made of\n and will determin how it should be handled")]
    [SerializeField] material _material;
    [Header("Describe the object, add any misalaniose things, jokes, puns")]
    [SerializeField] string description;
}
