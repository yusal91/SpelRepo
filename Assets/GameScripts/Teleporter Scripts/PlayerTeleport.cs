using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTeleport : MonoBehaviour
{
    private GameObject currentTeleporter;
    public AudioSource teleportSound;

    public List<TeleportClass> teleportList;


    public bool canTeleport;

    public TeleportClass GetTeleportByIndex(int index) => teleportList[index];
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && canTeleport)
        {
            teleportSound.Play();
            if(currentTeleporter != null)
            {
                transform.position = currentTeleporter.GetComponent<Teleporter>().GetDestination().position;      // get current postion and get destination postion
                Debug.Log("Teleported");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Teleporter"))
        {
            currentTeleporter = collision.gameObject;
            canTeleport = true;
            Debug.Log("Using Teleporter");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Teleporter"))
        {
            if(collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
                canTeleport = false;
            }
        }
    }
}
[System.Serializable]
public class TeleportClass
{
    public Transform teleportFrom;
    public Transform teleportToDestination;
}
