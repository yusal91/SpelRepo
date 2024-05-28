using UnityEngine;

public class Fireball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }    
}
