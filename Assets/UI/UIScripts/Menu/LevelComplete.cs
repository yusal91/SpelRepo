using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelComplete;
    private PauseMenu pauseMenu;    


    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("CompleteLevel"))
        {            
            LevelCompleted();
        }
    }

    public void LevelCompleted()
    {
        Debug.Log("Level Complete");
        levelComplete.SetActive(true);
        //pauseMenu.GetComponent<PauseMenu>().pauseMenuUI.SetActive(false);
    }

    public void RetryButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
