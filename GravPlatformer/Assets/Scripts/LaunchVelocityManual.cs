using UnityEngine;

public class LaunchVelocityManual : MonoBehaviour
{
    // values for speed, angle, and angular speed
    public float launchSpeed = 0f;
    [Tooltip("Measured CC starting from +X direction.")]
    public float launchAngle = 0f;
    [Tooltip("Deg/s CC")]
    public float angularSpeed = 0f;
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float angleRad = launchAngle * Mathf.Deg2Rad;

        // Calculate the X and Y components of the velocity vector.
        float velocityX = launchSpeed * Mathf.Cos(angleRad);
        float velocityY = launchSpeed * Mathf.Sin(angleRad);

        Vector2 initialVelocity = new Vector2(velocityX, velocityY);

        // Apply the calculated velocity directly to the Rigidbody.
        if (rb != null)
        {
            rb.linearVelocity = initialVelocity;
            rb.angularVelocity = angularSpeed;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found! Cannot apply initial velocity.");
        }
    }
}
