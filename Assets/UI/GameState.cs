using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public enum GameMode
    {
        Resumed,
        Paused,
        GameOver,
    } 

    public bool gameIsPaused;

    public GameMode gameMode;
    public bool playerCanMove;
    public bool enemiesCanMove;


    void Update()
    {
        switch (gameMode)
        {
            case GameMode.Paused:
                playerCanMove = false;
                enemiesCanMove = false;
                Time.timeScale = 0;
                break;
            case GameMode.Resumed:
                playerCanMove = true;
                enemiesCanMove = true;
                Time.timeScale = 1;
                break;
            case GameMode.GameOver:
                playerCanMove = false;
                enemiesCanMove = false;
                Time.timeScale = 1;
                break;
        }
    }

}
