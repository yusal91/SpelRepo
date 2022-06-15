using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public PowerUpEffect powerUpEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // check here for player / enemy
        Destroy(gameObject);
        Debug.Log("Healbuff Destoryed");
        powerUpEffect.Apply(collision.gameObject);  
    }
}
