using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingDecisionManager : MonoBehaviour
{
    [SerializeField] private List<TrashObj.material> recyclableMaterials;
    [SerializeField] private List<TrashObj.material> landfillMaterials;
    internal bool recycledLastItem = false;
    internal List<string> itemEffectsList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        GameplayManagers.Instance.GetEventManager().GetSortDecisionEvent().AddListener(PlayerSortActionDecision);
    }

    private void PlayerSortActionDecision(bool recycled)
    {
        if (ObjectShouldBeRecycled() == recycled)
            GameplayManagers.Instance.GetEventManager().InvokeSortCorrectness(true);
        else
            GameplayManagers.Instance.GetEventManager().InvokeSortCorrectness(false);
        itemEffectsList.Clear();
    }


    private bool ObjectShouldBeRecycled()
    {
        

        if (GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.GetComponent<LinkToScriptableObject>()._object != null)
        {
            TrashObj currentTrash = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.GetComponent<LinkToScriptableObject>()._object; // Get the current trash object
            Destinations currentDestination = GameplayManagers.Instance.GetDestinationManager().GetCurrentDestination();

            List<TrashObj.material> materialTypes = currentTrash.GetMaterialTypes();
            foreach (TrashObj.material material in materialTypes)
            {
                //check if you can actually recyle
                if (!recyclableMaterials.Contains(material) && recycledLastItem)
                {
                    return false; // If any material is not recyclable,and you clicked recylce return false
                }else if(recyclableMaterials.Contains(material) && !recycledLastItem){
                    return true;
                }

                
                //material checks
                if(material == TrashObj.material.PET_Plastic && itemEffectsList.Count > 0 && itemEffectsList[0] != "cut") return false;
                if(material == TrashObj.material.HDPE_Plastic && itemEffectsList.Count > 0 && itemEffectsList[0] != "cut") return false;
                if(material == TrashObj.material.Aluminum && itemEffectsList.Count > 0 && (itemEffectsList[0] != "cut" || itemEffectsList[1] != "melt")) return false;
                if(material == TrashObj.material.iron && itemEffectsList.Count > 0 && itemEffectsList[0] != "melt") return false;
                if(material == TrashObj.material.lead && itemEffectsList.Count > 0 && itemEffectsList[0] != "melt") return false;
                if(material == TrashObj.material.copper && itemEffectsList.Count > 0 && (itemEffectsList[0] != "cut" || itemEffectsList[1] != "melt")) return false;
                if(material == TrashObj.material.uranium && itemEffectsList.Count > 0 && itemEffectsList[0] != "wash") return false;
                if(material == TrashObj.material.wood && itemEffectsList.Count > 0 && itemEffectsList[0] != "cut") return false;

                //destination checks
                if(currentDestination == Destinations.Suburbia){
                    if(itemEffectsList.Count > 0 && itemEffectsList[0] != null && itemEffectsList[0] != "wash"){
                        return false;
                    }
                    if(itemEffectsList.Count > 1 && itemEffectsList[1] != null && itemEffectsList[1] != "cut"){
                        return false;
                    }
                    if(itemEffectsList.Count > 2 && itemEffectsList[2] != null && itemEffectsList[2] != "melt"){
                        return false;
                    }
                }
                if(currentDestination == Destinations.Untentia){
                    if(itemEffectsList.Count > 0 && itemEffectsList[0] != null && itemEffectsList[0] != "cut"){
                        return false;
                    }
                }
                if(currentDestination == Destinations.Metrock){
                    if(itemEffectsList.Count > 0 && itemEffectsList[0] != null && itemEffectsList[0] != "melt"){
                        return false;
                    }
                }
                if(currentDestination == Destinations.Middlesburg){
                    if(currentTrash.washed || currentTrash.cut || currentTrash.melted){
                        return false;
                    }
                }
                if(currentDestination == Destinations.Frugand){
                    if(itemEffectsList.Count > 0 && itemEffectsList[0] != null && itemEffectsList[0] != "wash"){
                        return false;
                    }
                    if(itemEffectsList.Count > 1 && itemEffectsList[1] != null && itemEffectsList[1] != "cut"){
                        return false;
                    }
                }
                if(currentDestination == Destinations.Alloyland){
                    if(itemEffectsList.Count > 0 && itemEffectsList[0] != null && itemEffectsList[0] != "cut"){
                        return false;
                    }
                    if(itemEffectsList.Count > 1 && itemEffectsList[1] != null && itemEffectsList[1] != "melt"){
                        return false;
                    }
                }
                if(currentDestination == Destinations.Radiolead){
                    if(itemEffectsList.Count > 0 && itemEffectsList[0] != null && itemEffectsList[0] != "wash"){
                        return false;
                    }
                    if(itemEffectsList.Count > 1 && itemEffectsList[1] != null && itemEffectsList[1] != "melt"){
                        return false;
                    }
                }
            }
            return true; // If all materials are recyclable, return true
        }
        return false; // default
    }
}
