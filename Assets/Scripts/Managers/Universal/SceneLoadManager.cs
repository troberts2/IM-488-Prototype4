using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public void LoadSceneByID(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void LoadSceneByName(string name){
        SceneManager.LoadScene(name);
    }

    public void ReloadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
