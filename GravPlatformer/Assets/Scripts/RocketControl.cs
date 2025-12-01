using UnityEngine;

public class RocketControl : MonoBehaviour
{
    [Header("Rotation Settings")]
    [Tooltip("How quickly the object rotates to the new direction (degrees per second).")]
    public float rotationSpeed = 300f;

    [Header("Movement Settings")]
    [Tooltip("The force applied when the Spacebar is held down.")]
    public float thrustForce = 5f;

    // Components
    private Rigidbody2D rb;

    void Awake()
    {
        // Get the Rigidbody2D component on startup
        rb = GetComponent<Rigidbody2D>();

        // Ensure Rigidbody2D is set up for 2D movement and rotation
        if (rb != null)
        {
            rb.gravityScale = 0f; // Typically want no gravity for top-down movement
            rb.angularDamping = 5f;  // Add some drag to angular velocity if needed
        }
    }

    void Update()
    {
        // 1. Handle WASD Rotation
        HandleRotation();
    }

    void FixedUpdate()
    {
        // 2. Handle Spacebar Thrust (Movement)
        // Physics updates should happen in FixedUpdate
        HandleMovement();
    }

    // --- Rotation Logic (Same as before) ---
    private void HandleRotation()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 inputDirection = new Vector2(horizontalInput, verticalInput).normalized;

        if (inputDirection.magnitude >= 0.1f)
        {
            float angle = Mathf.Atan2(inputDirection.y, inputDirection.x) * Mathf.Rad2Deg;

            // Offset to make the object's +Y axis face the input direction
            float targetAngle = angle - 90f;

            Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);

            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    // --- Movement Logic (New) ---
    private void HandleMovement()
    {
        // Check if the Spacebar is held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Get the object's 'forward' direction, which is its +Y axis in 2D
            // transform.up returns a Vector3 pointing in the object's local Y-axis direction 
            // relative to the world.
            Vector2 forwardDirection = transform.up;

            // Apply a force in the direction the object is currently facing
            // We use ForceMode2D.Force for continuous acceleration
            rb.AddForce(forwardDirection * thrustForce, ForceMode2D.Force);
        }
    }
}
