using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2UIManager : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject restartbuttonobject;
    [SerializeField] private GameObject quitbuttonobject;
    [SerializeField] private GameObject continuebuttonobject;

    private Level2StateManager _level2StateManager;

    void Start()
    {
        _level2StateManager = Level2Manager.Instance.Level2StateManager;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_level2StateManager.State)
        {
            case Level2State.Ready:
                HandleLevel2Ready();
                break;
            case Level2State.Running:
                HandleLevel2Running();
                break;
            case Level2State.GameOver:
                HandleLevel2GameOver();
                break;
            case Level2State.Finished:
                HandleLevel2GameFinished();
                break;
            default:
                break;
        }
    }
    private void HandleLevel2Ready()
    {
        messageText.text = "Ready For Level 2?\nPress [Space] to start";
        lifeText.text = "";
        scoreText.text = "";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel2Running()
    {
        messageText.text = "";
        lifeText.text = $"Life: {Level2Counter.life}";
        scoreText.text = $"Score: {Level2Counter.score}";
        restartbuttonobject.SetActive(false);
        quitbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel2GameOver()
    {
        messageText.text = "Game Over!\nPress [Space] to restart Level 2";
        restartbuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    }

    private void HandleLevel2GameFinished()
    {
        messageText.text = "You completed Level 2!";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    } 

    public void OnClickRestartButton()
    {
        _level2StateManager.RestartGame();
    }

    public void OnClickQuitButton()
    {
        _level2StateManager.QuitLevel2();
    }

    public void OnClickContinueButton()
    {
        _level2StateManager.ContinueToLevel3();
    }
}
