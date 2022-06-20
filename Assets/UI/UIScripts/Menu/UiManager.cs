using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;
    private PauseMenu pauseMenu;

    [Header("Level Complete Canvas")]
    public GameObject levelComplete;

    [Header("Game Over Canvas")]
    public GameObject gameOverCanvas;
 

    void Awake()
    {
        instance = this;
        pauseMenu = GetComponent<PauseMenu>();
    }  

    public void GameOverScene()
    {               
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game OVer");
        pauseMenu.enabled = false;
        Debug.Log("Pause Menu Deactivated");
    }

    public void LevelCompleted()
    {
        Debug.Log("Level Complete");
        levelComplete.SetActive(true);
        pauseMenu.enabled = false;
        //Debug.Log("Pause Menu Deactivated");        
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
