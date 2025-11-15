using UnityEngine;

// HOW TO USE THIS SCRIPT
// 1: Attach to player object
// 2: Attach an empty child game object to the player and place it at the player's feet
// 3: Drag the empty child game object into the playerMovement script in the player's inspector
// 4: Set the ground layer to the desired ground layer in the player's inspector (this will determine what resets the ability to jump)

// IMPORTANT NOTE: If you get an "InvalidOperations" error, then do the following vvv
// In the Unity project, go to edit -> project settings -> player -> other settings -> active input handling and set it to both

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private Vector2 groundCheckSize;

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
        groundCheckSize = boxCollider.size;

        groundCheckSize.x *= 1.1f;
        groundCheckSize.y *= 2f;
    }

    void Update()
    {
        // Ground Check
        isGrounded = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0f, groundLayer);

        // Horizontal Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jumping
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }
}
