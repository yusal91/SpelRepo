using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2D;

    [Header("Fireball and shooting transform")]
    public GameObject shootingPoint;
    public Fireball fireballPrefab;

    [Header("Player Health")]
    public int maxHealth = 100;
    public int currentHealth;
    //int noHealthLeft = 0;

    [Header("Health Bar")]
    public HealthBarScripts healthBar;

    [Header("Audio Source")]
    public AudioSource jumpSound;

    [Header("Movement Settings")]
    public float moveSpeed;
    private float moveX;
    float scaleX;

    [Header("Jump Settings")]
    public float jumpForce;
    public float fallMultiplier;
    public float gravity = 9.8f;
    Vector2 vecGravity;

    [Header("GroundCheck")]
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask whatisGround;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
        vecGravity = new Vector2(0, -Physics2D.gravity.y);       // falla ner snabare.

        currentHealth = maxHealth;                               // player HP at start
        healthBar.SetMaxHealth(maxHealth);                       // callback fr�n heatlbarscript - s�tta HP till full "MaxHealth"

        //rb2D.useFullKinematicContacts = true;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        Jumping();
        CastingFireball();
    }

    void FixedUpdate()
    {
        onMove();        
    }

    private void CastingFireball()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Instantiate(fireballPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);
            Debug.Log("PressingButton T");
        }
    }

    void onMove()
    {

        Rotation();
        
        rb2D.velocity = new Vector2(moveX * moveSpeed, rb2D.velocity.y - gravity * Time.deltaTime);    // skillnade mellan 2 fram "time.deltatime".

        if (rb2D.velocity.y < -90)                                        
        {            
            UiManager.instance.GameOverScene();                                   // aktivera Game Over Canvas
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);                                // health goes to 0
        }
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
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jumpSound.Play();
            rb2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            Debug.Log("Jumping");                        
        }

        if (rb2D.velocity.y < 0)
        {
            rb2D.velocity -= vecGravity * fallMultiplier * Time.deltaTime;     // beh�ver testa om man det g�r med time.deltaTime, som var recomanderat.  
            //Debug.Log("VecGravity" + fallMultiplier);
        }
    }
    void CheckIfGrounded()
    {        
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheck.GetComponent<CircleCollider2D>().radius, whatisGround);
        //Debug.Log("CheckifGrounded");
    }    

    public void TakeDamage(int damageTaken)
    {        
        currentHealth -= damageTaken;
        healthBar.SetHealth(currentHealth);
        NoHealth();
    }

    public void RestoreHealth(int restoreHealth)
    {
        if (currentHealth < maxHealth)
        {            
            currentHealth += restoreHealth;
            healthBar.SetHealth(currentHealth);
        }
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            healthBar.SetHealth(currentHealth);
        }       
    }

    public void NoHealth()                                   //  Fixed 
    {
        if (currentHealth <= 0)
        {
            UiManager.instance.GameOverScene();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LandEnemy"))                        // if enemy collides with player, player take damage.
        {
            TakeDamage(15);
            Debug.Log("Taking Damage");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("CompleteLevel"))                            // level complete 
        {
            UiManager.instance.LevelCompleted();
        }
    }
}
