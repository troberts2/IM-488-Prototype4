using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class MainCameraEffects : MonoBehaviour
{
    [SerializeField] private Volume _volumeComponent;
    [SerializeField] private VolumeComponent _volumeComp;
    [SerializeField] private List<float> _vIntensities;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameplayManagers.Instance.GetEventManager().GetSortCorrectnessEvent().AddListener(IncreaseVignetteIntensity);
    }

    void IncreaseVignetteIntensity(bool correct)
    {
        Debug.Log("increaseV");
        if (!correct)
        {
            Debug.Log("increasev3");
            if (_volumeComponent.profile.TryGet(out Vignette vi))
            {
                Debug.Log("v2");
                vi.intensity.value = _vIntensities[counter];
                Debug.Log(vi.intensity);
                counter++;
            }
        }
            
                

    }
}
