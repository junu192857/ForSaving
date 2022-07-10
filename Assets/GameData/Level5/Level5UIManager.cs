using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level5UIManager : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private GameObject restartbuttonobject;
    [SerializeField] private GameObject quitbuttonobject;
    [SerializeField] private GameObject continuebuttonobject;

    private Level5StateManager _level5StateManager;

    void Start()
    {
        _level5StateManager = Level5Manager.Instance.Level5StateManager;
    }

    // Update is called once per frame
    void Update()
    {
        switch(_level5StateManager.State)
        {
            case Level5State.Ready:
                HandleLevel5Ready();
                break;
            case Level5State.Running:
                HandleLevel5Running();
                break;
            case Level5State.GameOver:
                HandleLevel5GameOver();
                break;
            case Level5State.Finished:
                HandleLevel5GameFinished();
                break;
            default:
                break;
        }
    }
    private void HandleLevel5Ready()
    {
        messageText.text = "Ready For Level 5?\nPress [Space] to start";
        lifeText.text = "";
        scoreText.text = "";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel5Running()
    {
        messageText.text = "";
        lifeText.text = $"Life: {Level5Counter.life}";
        scoreText.text = $"Score: {Level5Counter.score}";
        restartbuttonobject.SetActive(false);
        quitbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(false);
    }

    private void HandleLevel5GameOver()
    {
        messageText.text = "Game Over!\nPress [Space] to restart Level 5";
        restartbuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    }

    private void HandleLevel5GameFinished()
    {
        messageText.text = "You completed Level 5!";
        restartbuttonobject.SetActive(false);
        continuebuttonobject.SetActive(true);
        quitbuttonobject.SetActive(true);
    } 

    public void OnClickRestartButton()
    {
        _level5StateManager.RestartGame();
    }

    public void OnClickQuitButton()
    {
        _level5StateManager.QuitLevel5();
    }

    public void OnClickContinueButton()
    {
        _level5StateManager.ContinueToLevel7();
    }
}
