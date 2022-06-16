using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelComplete;

    private void Start()
    {
        levelComplete.SetActive(false);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    collision.gameObject.CompareTag("CompleteLevel");
    //    levelComplete.SetActive(true);
    //    Debug.Log(levelComplete);
    //}


    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.CompareTag("CompleteLevel"))
        {
            levelComplete.SetActive(true);
            Debug.Log(levelComplete);
        }
    }

    public void RetryButton()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
