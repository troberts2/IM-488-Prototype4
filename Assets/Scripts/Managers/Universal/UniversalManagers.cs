using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalManagers : MonoBehaviour
{
    public static UniversalManagers Instance;
    /*[SerializeField] private SceneLoadManager _sceneLoadManager;
    [SerializeField] private AudioManager _audioManager;*/

    // Start is called before the first frame update
    void Awake()
    {
        EstablishSingleton();
    }

    private void EstablishSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            return;
        }
        Destroy(gameObject);
    }

    #region Get Managers
    /*public SceneLoadManager GetSceneLoadManager()
    {
        return _sceneLoadManager;
    }
    public AudioManager GetAudioManager()
    {
        return _audioManager;
    }*/
    #endregion
}
