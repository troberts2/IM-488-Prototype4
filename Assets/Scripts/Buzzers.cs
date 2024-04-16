using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzers : MonoBehaviour
{
    [SerializeField] private Animator _buzzerAnimator;
    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        GameplayManagers.Instance.GetEventManager().GetSortCorrectnessEvent().AddListener(BuzzerAction);
    }

    private void BuzzerAction(bool correct)
    {
        if (correct)
            BuzzerCorrect();
        else
            BuzzerIncorrect();
    }

    private void BuzzerCorrect()
    {
        _buzzerAnimator.SetTrigger("CorrectChoice");
    }

    private void BuzzerIncorrect()
    {
        _buzzerAnimator.SetTrigger("IncorrectChoice");
    }
}
