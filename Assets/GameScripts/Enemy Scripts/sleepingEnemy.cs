using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sleepingEnemy : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private float agroRange;
    [SerializeField]
    private float moveSpeed;

    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance to player;
        float distToPlayer = Vector2.Distance(transform.position, player.position);
        print("distToPlayer :" + distToPlayer);

        if(distToPlayer < agroRange)
        {
            // code to chase player
            ChasePlayer();
        }
        else
        {
            // stop chase player
            StopChasePlayer();
        }
    }   

    private void ChasePlayer()
    {
        if(transform.position.x < player.position.x)
        {
            // enemy is to the left side of the player, move to right.
            rb2D.velocity = new Vector2(moveSpeed, 0);
            // face the target in its direction
            transform.localScale = new Vector2(1, 1);
        }
        else if (transform.position.x > player.position.x)
        {
            // enemy is to right side of the player, move to the left;
            rb2D.velocity = new Vector2(-moveSpeed, 0);
            // face the target in its direction
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void StopChasePlayer()
    {
        rb2D.velocity  = Vector2.zero;  // shorter version of code below
        //rb2D.velocity = new Vector2(0, 0); // a bit longer version of code above.
    }

    // add raycast so enemy isnt following the player if there something in the way,   
}
