using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Level2State
{
    Ready,
    Running,
    GameOver,
    Finished
}
public class Level2StateManager : MonoBehaviour
{     
    public Level2State State {get; private set;}

    public void PrepareGame()
    {
        Time.timeScale = 0f;
        State = Level2State.Ready;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        State = Level2State.Running;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        State = Level2State.GameOver;
    }
    
    public void GameFinished()
    {
        Time.timeScale = 0f;
        State = Level2State.Finished;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        State = Level2State.Ready;
        Level2Counter.birdcount = 0;
        Level2Counter.score = 0;
        Level2Counter.life = 3;

        SceneManager.LoadScene("Scenes/SceneForLevel2");
    }


    public void QuitLevel2()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void ContinueToLevel3()
    {
        SceneManager.LoadScene("Scenes/Level2EventScene");
    }


    private void Start()
    {
        PrepareGame();
    }

    private void Update()
    {
        switch(State)
        {
            case Level2State.Ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("Scenes/MainMenuScene");
                }
                break;
            case Level2State.Running:
                break;
            case Level2State.GameOver:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel2();
                }
                break;
            case Level2State.Finished:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ContinueToLevel3();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel2();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    int[] prime = new int[] {2,3,5,7,11,13,17,19,23};
    public void OnClickShootButton()
    {
        if (State == Level2State.Running)
        {
        var result = Array.Exists(prime, x => x == Level2Counter.birdcount);
        if (result == true)
        {
            Level2Counter.score++;
            if (Level2Counter.score == 3)
            {
                GameFinished();
            }
        }
        else
        {
            Level2Counter.life --;
            if (Level2Counter.life == 0)
            {
                GameOver();
            }
        }
        }
    }



    
}
