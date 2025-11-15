using UnityEngine;

public class LaunchVelocityRandom : MonoBehaviour
{
    // values for speed, angle, and angular speed
    [Header("Launch speed range")]
    public float minLaunchSpeed = 0f;
    public float maxLaunchSpeed = 10f;
    [Header("Angle range measured CC starting from +X direction")]
    public float minLaunchAngle = 0f;
    public float maxLaunchAngle = 360f;
    [Header("Angular speed in Deg/s CC")]
    public float minAngularSpeed = -180f;
    public float maxAngularSpeed = 180f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        // randomly generate values
        float launchSpeed = Random.Range(minLaunchSpeed, maxLaunchSpeed);
        float launchAngle = Random.Range(minLaunchAngle, maxLaunchAngle);
        float angularSpeed = Random.Range(minAngularSpeed, maxAngularSpeed);

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
