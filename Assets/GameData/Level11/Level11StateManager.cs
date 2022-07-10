using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum Level11State
{
    Ready,
    Running,
    GameOver,
    Finished
}
public class Level11StateManager : MonoBehaviour
{     
    public Level11State State {get; private set;}

    public void PrepareGame()
    {
        Time.timeScale = 0f;
        State = Level11State.Ready;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;
        State = Level11State.Running;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        State = Level11State.GameOver;
    }
    
    public void GameFinished()
    {
        Time.timeScale = 0f;
        State = Level11State.Finished;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        State = Level11State.Ready;
        Level11Counter.peoplecount = 0;
        Level11Counter.wizardcount = 0;
        Level11Counter.bolchiecount = 0;
        Level11Counter.kidcount = 0;
        Level11Counter.score = 0;
        Level11Counter.life = 11;

        SceneManager.LoadScene("Scenes/SceneForLevel111");
    }


    public void QuitLevel11()
    {
        SceneManager.LoadScene("Scenes/MainMenuScene");
    }

    public void ContinueToEnding()
    {
        SceneManager.LoadScene("Scenes/Level11EventScene");
    }


    private void Start()
    {
        PrepareGame();
    }

    private void Update()
    {
        switch(State)
        {
            case Level11State.Ready:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    StartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    SceneManager.LoadScene("Scenes/MainMenuScene");
                }
                break;
            case Level11State.Running:
                break;
            case Level11State.GameOver:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    RestartGame();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel11();
                }
                break;
            case Level11State.Finished:
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    ContinueToEnding();
                }
                else if(Input.GetKeyDown(KeyCode.Escape))
                {
                    QuitLevel11();
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    int[] prime = new int[] {2,3,5,7,11,13,17,19,23};
    public void OnClickShootButton()
    {
        if (State == Level11State.Running)
        {

        int count = 0;
        if (Array.Exists(prime, x => x == Level11Counter.peoplecount)) count++;
        if (Array.Exists(prime, x => x == Level11Counter.wizardcount)) count++;
        if (Array.Exists(prime, x => x == Level11Counter.kidcount)) count++;
        if (Array.Exists(prime, x => x == Level11Counter.bolchiecount)) count++;

            Level11Counter.score += count;
            Level11Counter.life -= (4 - count);


        if (Level11Counter.life <= 0)
        {
            GameOver();
        }
        else if (Level11Counter.score >= 11)
        {
            GameFinished();
        }
        }
    }



    
}
