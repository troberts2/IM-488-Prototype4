using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrashHandleScript : MonoBehaviour
{
    [SerializeField] Material testSparkly;
    [SerializeField] GameObject cutObjectPrefab;
    [SerializeField] Button recycle;
    [SerializeField] Button discard;
    bool melt = false;

    private void OnEnable()
    {
        recycle.enabled = true;
        discard.enabled = true;
    }
    private bool melting = false;
    private void Update() {

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

        objMat = GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.GetComponent<MeshRenderer>().material = meltMaterial;
        objMat.SetFloat("_CutoffHeight", GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash.transform.position.y * 2);
        StartCoroutine(Melt(4f));
    }
    IEnumerator Melt(float time){
        float counter = 0;
        while (counter <= time){
            counter += Time.deltaTime;
            objMat.SetFloat("_CutoffHeight", meltMaterial.GetFloat("_CutoffHeight") - .005f);
            yield return null;
        }
        objMat = null;
    }

    public void DiscardTrash()
    {
        discard.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash);
        if(cutObject != null) Destroy(cutObject);
        GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;


        GameplayManagers.Instance.GetEventManager().InvokeDiscardSort();
        print("help");
    }

    public void RecycleTrash()
    {
        recycle.enabled = false;
        Destroy(GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().currentTrash);
        if(cutObject != null) Destroy(cutObject);
        GameObject.FindGameObjectWithTag("Conveyor").GetComponent<Conveyor>().GetComponentInChildren<TrashSpawner>().isReadyForNextItem = true;

        GameplayManagers.Instance.GetEventManager().InvokeRecycleSort();
        print("help");
    }

    
}
