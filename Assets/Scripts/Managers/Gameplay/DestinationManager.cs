using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestinationManager : MonoBehaviour
{
    [SerializeField] TMP_Text _destinationText;

    private Destinations _currentDestination;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDestinationUI();
    }

    public void ProgressDestination()
    {
        _currentDestination++;
        if ((int)_currentDestination > 5)
            _currentDestination = Destinations.Suburbia;

        UpdateDestinationUI();
    }

    private void UpdateDestinationUI()
    {
        _destinationText.text = _currentDestination.ToString();
            ToString();
    }
    
}

enum Destinations
{
    Suburbia,
    Untentia,
    Metrock,
    Middlesburg,
    Frugand,
    Alloyland
};
