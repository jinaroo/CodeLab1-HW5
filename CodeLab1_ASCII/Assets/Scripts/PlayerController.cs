using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public float maxSpeed;
    public float jumpForce;
    
    // ground check
    private bool grounded = false;
    public Transform groundCheck;
    public float groundRadius = 1f;
    public LayerMask whatIsGround;
    
    // controls
    public KeyCode jump;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        // movement
        float moveDirection = Input.GetAxis("Horizontal"); // checks to see if player is going left or right
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection*maxSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);

        if (grounded && Input.GetKeyDown(jump))
        {
            Debug.Log("JUMPING WOO");
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }
            
    }
}
