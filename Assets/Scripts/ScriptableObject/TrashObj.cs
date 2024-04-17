using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[CreateAssetMenu(fileName = "newTrash", menuName = "Trash", order = 1)]
public class TrashObj : ScriptableObject
{

    public enum material
    {
        wood,//recyclable
        paper,//recyclable
        Aluminum,//recyclable
        iron,
        copper,//recyclable
        uranium,
        PET_Plastic,//recyclable
        HDPE_Plastic,//recyclable
        PVC_Plastic,
        PS_Plastic,
        lead
    }
    public bool cut = false;
    public bool washed = false;
    public bool melted = false;


    [Header("The name of the object")]
    public string objName;
    [Header("The game object that will be representing the object")]
    public GameObject visualRepresentation;
    //the material the object is made of
    [Header("The material the object is made of\n and will determin how it should be handled")]
    List<material> _material = new List<material>();
    public string materialName;
    [Header("Describe the object, add any misalaniose things, jokes, puns")]
    public string description;

    

    public void CreateTrash(int numOfMaterialsMadeOf)
    {
        for (int i = 0; i < numOfMaterialsMadeOf; i++)
        {
            switch (Random.Range(((int)material.wood),((int)material.PS_Plastic)))
            {
                case ((int)material.wood):
                    _material.Add(material.wood);
                    materialName = "wood";
                    break;
                case ((int)material.paper):
                    _material.Add(material.paper);
                    materialName = "paper";
                    break;
                case ((int)material.Aluminum):
                    _material.Add(material.Aluminum);
                    materialName = "aluminum";
                    break;
                case ((int)material.iron):
                    _material.Add(material.iron);
                    materialName = "iron";
                    break;
                case ((int)material.copper):
                    _material.Add(material.copper);
                    materialName = "copper";
                    break;
                case ((int)material.uranium):
                    _material.Add(material.uranium);
                    materialName = "uranium";
                    break;
                case ((int)material.PET_Plastic):
                    _material.Add(material.PET_Plastic);
                    materialName = "PET plastic";
                    break;
                case ((int)material.HDPE_Plastic):
                    _material.Add(material.HDPE_Plastic);
                    materialName = "HDPE plastic";
                    break;
                case ((int)material.PVC_Plastic):
                    _material.Add(material.PVC_Plastic);
                    materialName = "PVC plastic";
                    break;
                case ((int)material.PS_Plastic):
                    _material.Add(material.PS_Plastic);
                    materialName = "PS plastic";
                    break;
                default:
                    break;
            
            }
        }

        

    }

    public List<material> GetMaterialTypes()
    {
        return _material;
    }




}
