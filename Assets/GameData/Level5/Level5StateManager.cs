using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Level5State
{
    Ready,
    Running,
    GameOver,
    Finished
}
public class Level5StateManager : MonoBehaviour
{     
    public Level5State State {get; private set;}

    public void PrepareGame()
    {
        Time.timeScale = 0f;
        State = Level5State.Ready;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        State = Level5State.Running;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        State = Level5State.GameOver;
    }
    
    public void GameFinished()
    {
        Time.timeScale = 0f;
        State = Level5State.Finished;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        State = Level5State.Ready;
        Level5Counter.birdcount = 0;
        Level5Counter.redbirdcount = 0;
        Level5Counter.score = 0;
        Level5Counter.life = 5;

        SceneManager.LoadScene("Scenes/SceneForLevel5");
    }


    public void QuitLevel5()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void ContinueToLevel7()
    {
        SceneManager.LoadScene("Scenes/Level5EventScene");
    }


    private void Start()
    {
        PrepareGame();
    }

    private void Update()
    {
        switch(State)
        {
            case Level5State.Ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("Scenes/MainMenuScene");
                }
                break;
            case Level5State.Running:
                break;
            case Level5State.GameOver:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel5();
                }
                break;
            case Level5State.Finished:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ContinueToLevel7();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel5();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    int[] prime = new int[] {2,3,5,7,11,13,17,19,23};
    public void OnClickShootButton()
    {
        if (State == Level5State.Running)
        {
        var result = Array.Exists(prime, x => x == Level5Counter.birdcount);
        var result2 = Array.Exists(prime, x => x == Level5Counter.redbirdcount);
        if (result == true)
        {
            Level5Counter.score++;
        }
        else
        {
            Level5Counter.life --;
        }
        if (result2 == true)
        {
            Level5Counter.score++;
        }
        else
        {
            Level5Counter.life --;
        }
        if (Level5Counter.life <= 0)
        {
            GameOver();
        }
        else if (Level5Counter.score >= 5)
        {
            GameFinished();
        }
        }
    }



    
}
