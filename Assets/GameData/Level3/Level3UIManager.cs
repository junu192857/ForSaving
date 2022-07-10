using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level3UIManager : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject restartbuttonobject;
    [SerializeField] private GameObject quitbuttonobject;
    [SerializeField] private GameObject continuebuttonobject;

    private Level3StateManager _level3StateManager;

    void Start()
    {
        _level3StateManager = Level3Manager.Instance.Level3StateManager;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_level3StateManager.State)
        {
            case Level3State.Ready:
                HandleLevel3Ready();
                break;
            case Level3State.Running:
                HandleLevel3Running();
                break;
            case Level3State.GameOver:
                HandleLevel3GameOver();
                break;
            case Level3State.Finished:
                HandleLevel3GameFinished();
                break;
            default:
                break;
        }
    }
    private void HandleLevel3Ready()
    {
        messageText.text = "Ready For Level 3?\nPress [Space] to start";
        lifeText.text = "";
        scoreText.text = "";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel3Running()
    {
        messageText.text = "";
        lifeText.text = $"Life: {Level3Counter.life}";
        scoreText.text = $"Score: {Level3Counter.score}";
        restartbuttonobject.SetActive(false);
        quitbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel3GameOver()
    {
        messageText.text = "Game Over!\nPress [Space] to restart Level 3";
        restartbuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    }

    private void HandleLevel3GameFinished()
    {
        messageText.text = "You completed Level 3!";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    } 

    public void OnClickRestartButton()
    {
        _level3StateManager.RestartGame();
    }

    public void OnClickQuitButton()
    {
        _level3StateManager.QuitLevel3();
    }

    public void OnClickContinueButton()
    {
        _level3StateManager.ContinueToLevel5();
    }
}
