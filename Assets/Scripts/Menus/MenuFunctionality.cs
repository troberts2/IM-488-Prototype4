using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void LoadSpecificScene(int sceneID)
    {
        UniversalManagers.Instance.GetSceneLoadManager().LoadSceneByID(sceneID);
    }
}
