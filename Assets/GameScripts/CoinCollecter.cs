using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollecter : MonoBehaviour
{
    public AudioSource dingSound;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Collectable"))
        {
            dingSound.Play();
            string itemType = collision.gameObject.GetComponent<CollectableCoins>().itemType;
            print("Coin Collected a:" + itemType);
            //Debug.Log(GameManager.instance);
            //Debug.Log(GameManager.instance.items);
            GameManager.instance.items.Add(itemType);                                   
            Destroy(collision.gameObject);
        }
    }

   
}
