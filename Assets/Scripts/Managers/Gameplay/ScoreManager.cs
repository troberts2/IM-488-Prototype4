using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int _scoreToWin;
    [SerializeField] private int _mistakesToLose;
    private int _currentScore;
    private int _currentMistakes;
    // Start is called before the first frame update
    

    public void SubscribeToEvents()
    {
        GameplayManagers.Instance.GetEventManager().GetSortCorrectnessEvent().AddListener(PlayerSorted);
    }

    private void PlayerSorted(bool correct)
    {
        if (correct)
            IncrementScore();
        else
            IncrementMistake();
    }

    private void IncrementScore()
    {
        _currentScore++;
        Debug.Log("points" + _currentScore);
        if (_currentScore >= _scoreToWin)
            PlayerWon();
    }

    private void IncrementMistake()
    {
        _currentMistakes++;
        Debug.Log("mistakes:" + _currentMistakes);
        if (_currentMistakes >= _mistakesToLose)
            PlayerLost();
    }

    private void PlayerWon()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameplayManagers.Instance.GetSceneLoadManager().LoadSceneByName("WinScene");
    }

    private void PlayerLost()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameplayManagers.Instance.GetSceneLoadManager().LoadSceneByName("LossScene");
    }
}
