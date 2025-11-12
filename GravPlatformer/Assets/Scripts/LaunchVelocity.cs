using UnityEngine;

public class LaunchVelocity : MonoBehaviour
{
    // ... [Header and variables remain the same] ...
    public float launchSpeed = 5f;
    public float launchAngle = 45f;
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

        // 4. Apply the calculated velocity directly to the Rigidbody.
        if (rb != null)
        {
            // --- FIX APPLIED HERE ---
            rb.linearVelocity = initialVelocity;
        }
        else
        {
            Debug.LogError("Rigidbody2D component not found! Cannot apply initial velocity.");
        }
    }
}
