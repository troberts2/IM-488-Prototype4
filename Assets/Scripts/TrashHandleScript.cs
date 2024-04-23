using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashHandleScript : MonoBehaviour
{
    [SerializeField] Material testSparkly;
    [SerializeField] GameObject cutObjectPrefab;
    public Color ogTrashColor;
    /*[SerializeField] Button recycle;
    [SerializeField] Button discard;*/
    bool melt = false;

    private void OnEnable()
    {
        //recycle.enabled = true;
        //discard.enabled = true;
    }
    private void Update() {
        if(melt) Melt();
    }
    private GameObject cutObject;

    public void CutTrash()
    {
        if(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash == null) return;

        GameObject currentTrash = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash;
        TrashObj trashObj = currentTrash.GetComponent<LinkToScriptableObject>()._object;
        trashObj.cut = true;
        ogTrashColor = currentTrash.GetComponentInChildren<MeshRenderer>().material.color;
        objMat = new Material(currentTrash.GetComponentInChildren<MeshRenderer>().material);

        if(currentTrash.GetComponent<MeshRenderer>() != null)
        currentTrash.GetComponent<MeshFilter>().mesh.Clear();
        //currentTrash.GetComponent<MeshFilter>().mesh.Clear();

        foreach (MeshFilter mf in currentTrash.GetComponentsInChildren<MeshFilter>())
            mf.mesh.Clear();

        if(cutObject == null)
        cutObject = Instantiate(cutObjectPrefab, currentTrash.transform.position, Quaternion.identity);
        // if (currentTrash.GetComponent<MeshFilter>().mesh == null) // Check if the GameObject itself doesn't have a MeshRenderer
        // {
        ChangeChildrenMaterial(cutObject.transform, objMat); // Call a recursive function to change the material of all children
        //}
    }

    public void WashTrash()
    {
        if(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash == null) return;

        GameObject currentTrash = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash;
        TrashObj trashObj = currentTrash.GetComponent<LinkToScriptableObject>()._object;
        trashObj.washed = true;
        testSparkly.SetColor("_Base_Color_1", ogTrashColor);

        if (cutObject != null) // Check if the GameObject itself doesn't have a MeshRenderer
        {
            ChangeChildrenMaterial(cutObject.transform, testSparkly); // Call a recursive function to change the material of all children
        }else
        currentTrash.GetComponent<MeshRenderer>().material = testSparkly;

        foreach (MeshRenderer mr in currentTrash.GetComponentsInChildren<MeshRenderer>())
            mr.material = testSparkly;

        Debug.Log(trashObj.washed);
    }
    [SerializeField]private Material meltMaterial;
    Material objMat;
    public void MeltTrash()
    {
        if(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash == null) return;
        meltMaterial.SetColor("_Trash_Color", ogTrashColor);

        GameObject currentTrash = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash;
        TrashObj trashObj = currentTrash.GetComponent<LinkToScriptableObject>()._object;
        trashObj.melted = true;

        if (cutObject != null) // Check if the GameObject itself doesn't have a MeshRenderer
        {
            ChangeChildrenMaterial(cutObject.transform, meltMaterial); // Call a recursive function to change the material of all children
        }else
        objMat = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.GetComponent<MeshRenderer>().material = meltMaterial;

        foreach (MeshRenderer mr in currentTrash.GetComponentsInChildren<MeshRenderer>())
            mr.material = meltMaterial;
        melt = true;
        Debug.Log(trashObj.melted);
    }
    private float startValue = -1f; // Starting value of the float property
    private float endValue = 1f; // Ending value of the float property
    private float duration = 2f; // Duration of the transition in seconds
    private float currentTime = 0f;
    
    void Melt(){
        // Increment current time
        currentTime += Time.deltaTime;
        // Calculate t value between 0 and 1 based on current time and duration
        float t = Mathf.Clamp01(currentTime / duration);
        // Calculate the interpolated value between startValue and endValue
        float floatValue = Mathf.Lerp(startValue, endValue, t);
        // Set the float property in the material
        objMat.SetFloat("_Dissolve", floatValue);
        // Reset time and value if duration is exceeded
        if (currentTime >= duration)
        {
            currentTime = 0f;
            melt = false;
        }
    }
    void ChangeChildrenMaterial(Transform parent, Material newMaterial)
    {
        foreach (Transform child in parent)
        {
            MeshRenderer renderer = child.GetComponent<MeshRenderer>();
            if (renderer != null) // Check if the child has a Renderer component
            {
                renderer.material = newMaterial; // Change the material
            }
            else
            {
                ChangeChildrenMaterial(child, newMaterial); // Recursively call the function for all children
            }
        }
    }
    public void RecycleTrash()
    {
        //recycle.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash);
        if(cutObject != null) Destroy(cutObject);
        GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;
        GameplayManagers.Instance.GetSortingDecisionManager().recycledLastItem = true;

        GameplayManagers.Instance.GetEventManager().InvokeSortDecision(true);
        //print("help");
    }

    public void DiscardTrash()
    {
        //discard.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash);
        if (cutObject != null) Destroy(cutObject);
        GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;
        GameplayManagers.Instance.GetSortingDecisionManager().recycledLastItem = false;


        GameplayManagers.Instance.GetEventManager().InvokeSortDecision(false);
        //print("help");
    }

}
