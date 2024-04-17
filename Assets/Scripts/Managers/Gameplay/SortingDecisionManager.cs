using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingDecisionManager : MonoBehaviour
{
    [SerializeField] private List<TrashObj.material> recyclableMaterials;
    [SerializeField] private List<TrashObj.material> landfillMaterials;
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
        Debug.Log(ObjectShouldBeRecycled());
    }


    private bool ObjectShouldBeRecycled()
    {
        TrashObj currentTrash = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.GetComponent<LinkToScriptableObject>()._object; // Get the current trash object

        if (currentTrash != null)
        {
            Destinations currentDestination = GameplayManagers.Instance.GetDestinationManager().GetCurrentDestination();

            List<TrashObj.material> materialTypes = currentTrash.GetMaterialTypes();
            foreach (TrashObj.material material in materialTypes)
            {
                if (!recyclableMaterials.Contains(material))
                {
                    return false; // If any material is not recyclable, return false
                }
                //material checks
                if(material == TrashObj.material.PET_Plastic && !currentTrash.cut) return false;
                if(material == TrashObj.material.HDPE_Plastic && !currentTrash.cut) return false;
                if(material == TrashObj.material.Aluminum && (!currentTrash.cut || !currentTrash.melted)) return false;
                if(material == TrashObj.material.iron && !currentTrash.melted) return false;
                if(material == TrashObj.material.lead && !currentTrash.melted) return false;
                if(material == TrashObj.material.copper && (!currentTrash.cut || !currentTrash.melted)) return false;
                if(material == TrashObj.material.uranium && !currentTrash.washed) return false;
                if(material == TrashObj.material.wood && !currentTrash.cut) return false;

                //destination checks
                if(currentDestination == Destinations.Suburbia && (!currentTrash.washed || !currentTrash.cut || !currentTrash.melted)) return false;
                if(currentDestination == Destinations.Untentia && (!currentTrash.cut)) return false;
                if(currentDestination == Destinations.Metrock && (!currentTrash.melted)) return false;
                if(currentDestination == Destinations.Middlesburg && (currentTrash.washed || currentTrash.cut || currentTrash.melted)) return false;
                if(currentDestination == Destinations.Frugand && (!currentTrash.washed || !currentTrash.cut)) return false;
                if(currentDestination == Destinations.Alloyland && (!currentTrash.cut || !currentTrash.melted)) return false;
                if(currentDestination == Destinations.Radiolead && (!currentTrash.washed || !currentTrash.melted)) return false;
            }
            return true; // If all materials are recyclable, return true
        }
        return false; // default
    }
}
