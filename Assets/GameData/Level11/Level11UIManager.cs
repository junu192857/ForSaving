using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level11UIManager : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject restartbuttonobject;
    [SerializeField] private GameObject quitbuttonobject;
    [SerializeField] private GameObject continuebuttonobject;

    private Level11StateManager _level11StateManager;

    void Start()
    {
        _level11StateManager = Level11Manager.Instance.Level11StateManager;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_level11StateManager.State)
        {
            case Level11State.Ready:
                HandleLevel11Ready();
                break;
            case Level11State.Running:
                HandleLevel11Running();
                break;
            case Level11State.GameOver:
                HandleLevel11GameOver();
                break;
            case Level11State.Finished:
                HandleLevel11GameFinished();
                break;
            default:
                break;
        }
    }
    private void HandleLevel11Ready()
    {
        messageText.text = "Ready For Level 11?\nPress [Space] to start";
        lifeText.text = "";
        scoreText.text = "";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel11Running()
    {
        messageText.text = "";
        lifeText.text = $"Life: {Level11Counter.life}";
        scoreText.text = $"Score: {Level11Counter.score}";
        restartbuttonobject.SetActive(false);
        quitbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel11GameOver()
    {
        messageText.text = "Game Over!\nPress [Space] to restart Level 11";
        restartbuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    }

    private void HandleLevel11GameFinished()
    {
        messageText.text = "You completed Level 11!";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    } 

    public void OnClickRestartButton()
    {
        _level11StateManager.RestartGame();
    }

    public void OnClickQuitButton()
    {
        _level11StateManager.QuitLevel11();
    }

    public void OnClickContinueButton()
    {
        _level11StateManager.ContinueToEnding();
    }
}
