using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level7UIManager : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject restartbuttonobject;
    [SerializeField] private GameObject quitbuttonobject;
    [SerializeField] private GameObject continuebuttonobject;

    private Level7StateManager _level7StateManager;

    void Start()
    {
        _level7StateManager = Level7Manager.Instance.Level7StateManager;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_level7StateManager.State)
        {
            case Level7State.Ready:
                HandleLevel7Ready();
                break;
            case Level7State.Running:
                HandleLevel7Running();
                break;
            case Level7State.GameOver:
                HandleLevel7GameOver();
                break;
            case Level7State.Finished:
                HandleLevel7GameFinished();
                break;
            default:
                break;
        }
    }
    private void HandleLevel7Ready()
    {
        messageText.text = "Ready For Level 7?\nPress [Space] to start";
        lifeText.text = "";
        scoreText.text = "";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel7Running()
    {
        messageText.text = "";
        lifeText.text = $"Life: {Level7Counter.life}";
        scoreText.text = $"Score: {Level7Counter.score}";
        restartbuttonobject.SetActive(false);
        quitbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel7GameOver()
    {
        messageText.text = "Game Over!\nPress [Space] to restart Level 7";
        restartbuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    }

    private void HandleLevel7GameFinished()
    {
        messageText.text = "You completed Level 7!";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    } 

    public void OnClickRestartButton()
    {
        _level7StateManager.RestartGame();
    }

    public void OnClickQuitButton()
    {
        _level7StateManager.QuitLevel7();
    }

    public void OnClickContinueButton()
    {
        _level7StateManager.ContinueToLevel11();
    }
}
