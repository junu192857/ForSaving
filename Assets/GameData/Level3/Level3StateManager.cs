using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Level3State
{
    Ready,
    Running,
    GameOver,
    Finished
}
public class Level3StateManager : MonoBehaviour
{     
    public Level3State State {get; private set;}

    public void PrepareGame()
    {
        Time.timeScale = 0f;
        State = Level3State.Ready;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        State = Level3State.Running;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        State = Level3State.GameOver;
    }
    
    public void GameFinished()
    {
        Time.timeScale = 0f;
        State = Level3State.Finished;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        State = Level3State.Ready;
        Level3Counter.birdcount = 0;
        Level3Counter.score = 0;
        Level3Counter.life = 3;

        SceneManager.LoadScene("Scenes/SceneForLevel3");
    }


    public void QuitLevel3()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void ContinueToLevel5()
    {
        SceneManager.LoadScene("Scenes/Level3EventScene");
    }


    private void Start()
    {
        PrepareGame();
    }

    private void Update()
    {
        switch(State)
        {
            case Level3State.Ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("Scenes/MainMenuScene");
                }
                break;
            case Level3State.Running:
                break;
            case Level3State.GameOver:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel3();
                }
                break;
            case Level3State.Finished:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ContinueToLevel5();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel3();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    int[] prime = new int[] {2,3,5,7,11,13,17,19,23};
    public void OnClickShootButton()
    {
        if (State == Level3State.Running)
        {
        var result = Array.Exists(prime, x => x == Level3Counter.birdcount);
        if (result == true)
        {
            Level3Counter.score++;
            if (Level3Counter.score == 3)
            {
                GameFinished();
            }
        }
        else
        {
            Level3Counter.life --;
            if (Level3Counter.life == 0)
            {
                GameOver();
            }
        }
        }
    }



    
}
