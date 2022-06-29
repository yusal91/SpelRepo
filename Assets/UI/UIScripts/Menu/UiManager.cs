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

    [Header("Final Score Text")]
    public Text brozCoin;
    public Text silvrCoin;
    public Text golCoin;



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
        Debug.Log("Pause Menu Deactivated");
        
        brozCoin.text = ScoreManager.instance.bronzeCoinCollected.ToString() + " Bronze Coin / 14 ";
        silvrCoin.text = ScoreManager.instance.silverCoinCollected.ToString() + " Silver Coin / 10 ";
        golCoin.text = ScoreManager.instance.goldCoinCollected.ToString() + " Gold Coin  / 7 ";
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
