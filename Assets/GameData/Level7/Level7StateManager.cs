using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Level7State
{
    Ready,
    Running,
    GameOver,
    Finished
}
public class Level7StateManager : MonoBehaviour
{     
    public Level7State State {get; private set;}

    public void PrepareGame()
    {
        Time.timeScale = 0f;
        State = Level7State.Ready;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        State = Level7State.Running;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        State = Level7State.GameOver;
    }
    
    public void GameFinished()
    {
        Time.timeScale = 0f;
        State = Level7State.Finished;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        State = Level7State.Ready;
        Level7Counter.birdcount = 0;
        Level7Counter.redbirdcount = 0;
        Level7Counter.score = 0;
        Level7Counter.life = 7;

        SceneManager.LoadScene("Scenes/SceneForLevel7");
    }


    public void QuitLevel7()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void ContinueToLevel11()
    {
        SceneManager.LoadScene("Scenes/Level7EventScene");
    }


    private void Start()
    {
        PrepareGame();
    }

    private void Update()
    {
        switch(State)
        {
            case Level7State.Ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("Scenes/MainMenuScene");
                }
                break;
            case Level7State.Running:
                break;
            case Level7State.GameOver:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel7();
                }
                break;
            case Level7State.Finished:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ContinueToLevel11();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel7();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    int[] prime = new int[] {2,3,5,7,11,13,17,19,23};
    public void OnClickShootButton()
    {
        if (State == Level7State.Running)
        {
        var result = Array.Exists(prime, x => x == Level7Counter.birdcount);
        var result2 = Array.Exists(prime, x => x == Level7Counter.redbirdcount);
        if (result == true)
        {
            Level7Counter.score++;
        }
        else
        {
            Level7Counter.life --;
        }
        if (result2 == true)
        {
            Level7Counter.score++;
        }
        else
        {
            Level7Counter.life --;
        }
        if (Level7Counter.life <= 0)
        {
            GameOver();
        }
        else if (Level7Counter.score >= 7)
        {
            GameFinished();
        }
        }
    }



    
}
