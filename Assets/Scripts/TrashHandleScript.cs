using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashHandleScript : MonoBehaviour
{
    [SerializeField] Material testSparkly;
    [SerializeField] GameObject cutObjectPrefab;
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

        currentTrash.SetActive(false);
        cutObject = Instantiate(cutObjectPrefab, currentTrash.transform.position, Quaternion.identity);
    }

    public void WashTrash()
    {
        if(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash == null) return;

        GameObject currentTrash = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash;
        currentTrash.GetComponent<MeshRenderer>().material = testSparkly;
    }
    [SerializeField]private Material meltMaterial;
    Material objMat;
    public void MeltTrash()
    {
        if(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash == null) return;
        meltMaterial.SetColor("_Trash_Color", GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.GetComponent<MeshRenderer>().material.color);

        objMat = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.GetComponent<MeshRenderer>().material = meltMaterial;
        melt = true;
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

    public void RecycleTrash()
    {
        //recycle.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash);
        if(cutObject != null) Destroy(cutObject);
        GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;

        GameplayManagers.Instance.GetEventManager().InvokeSortDecision(true);
        //print("help");
    }

    public void DiscardTrash()
    {
        //discard.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash);
        if (cutObject != null) Destroy(cutObject);
        GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;


        GameplayManagers.Instance.GetEventManager().InvokeSortDecision(false);
        //print("help");
    }

}
