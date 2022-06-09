using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [Header("Player Script")]    
    private PlayerControl playerControl;


    [Header("Enemy Transforms")]
    public List<Transform> points;          // Referance till väg punkt

    public int nextID = 0;                 // Int value för next punkt

    int idChangeValue = 1;                // The Value of that applies to ID for changing

    public float speed = 2;              // Rörlse value for enemy AI

    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnenmyOnPatrol();
    }

    void EnenmyOnPatrol()
    {
        Transform goalPoint = points[nextID];                              // get next transform points

        if (goalPoint.transform.position.x > transform.position.x)         // Flip the enemy to look into the direction its facing
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position = Vector2.MoveTowards(transform.position,
                             goalPoint.position, speed * Time.deltaTime);        // Move the Enemy towards the goal points || towards player.           

        if (Vector2.Distance(transform.position, goalPoint.position) < 1f)        // Check the distance between enemy and goal point to trigger next point   
        {
            if (nextID == points.Count - 1)                                       // check if we are at the end of the line( make the change -1)
            {
                idChangeValue = -1;
            }
            if (nextID == 0)                                                     // Check if we are at the start of the line (make the change +1)
            {
                idChangeValue = +1;
            }

            nextID += idChangeValue;                                          // Apply the change on the nextID                                                                             
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))                        // if enemy collides with player, player take damage.
        {
            playerControl.TakeDamage(20);
            Debug.Log("Player Taking Damage");
        }
    }
}
