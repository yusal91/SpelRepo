using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameObject gameOverCanvas;


    public void GameOverScene()
    {
        //playerControl.NoHealth();        
        gameOverCanvas.SetActive(true);
        Debug.Log("Game OVer");

    }

}
