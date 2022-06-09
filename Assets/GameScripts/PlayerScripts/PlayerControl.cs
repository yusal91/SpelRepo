using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Player Health")]
    public int maxHealth = 100;
    public int currentHealth;

    [Header("Health Bar")]
    public HealthBarScripts healthBar;

    [Header("Movement Settings")]
    public float moveSpeed;
    private float moveX;    
    float scaleX;

    [Header("Jump Settings")]
    public float jumpForce;

    [Header("GroundCheck")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatisGround;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;

        currentHealth = maxHealth;                               // player HP at start
        healthBar.SetMaxHealth(maxHealth);                       // callback från heatlbarscript - sätta HP till full "MaxHealth"
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        Jumping();        
    }

    void FixedUpdate()
    {
        onMove();        
    }

    void onMove()
    {
        Rotation();
        rb2D.velocity = new Vector2(moveX * moveSpeed, rb2D.velocity.y);    // skillnade mellan 2 fram "time.deltatime".
        
    }

    void Rotation()
    {
        if(moveX > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if(moveX < 0)
        {
            transform.localScale = new Vector3((-1) * scaleX, transform.localScale.y, transform.localScale.z);
        }
    }

    void Jumping()
    {
        CheckIfGrounded();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                //rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
                rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                Debug.Log("Jumping");
            }
            
        }
             
    }
    void CheckIfGrounded()
    {
        //var groundComponent = GetComponent<BoxCollider2D>();
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheck.GetComponent<CircleCollider2D>().radius, whatisGround);
        //Debug.Log("CheckifGrounded");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
