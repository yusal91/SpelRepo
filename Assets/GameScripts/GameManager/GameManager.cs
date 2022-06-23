using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<string> items;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        items = new List<string>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instance == null)
        {
            instance = this;              // TODO: REMOVE BEFORE RELEASE.
        }
    }
}
