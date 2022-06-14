using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBouce : MonoBehaviour
{
    public float jumpForceMushrrom = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForceMushrrom, ForceMode2D.Impulse);
        }
    }
}
