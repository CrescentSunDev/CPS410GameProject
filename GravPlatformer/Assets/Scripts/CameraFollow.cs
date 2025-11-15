using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The player's Transform component to follow
    public Transform target;

    // How quickly the camera catches up to the target
    public float smoothSpeed = 0.5f;

    // The offset distance between the camera and the target
    public Vector3 offset = new Vector3(0f, 0f, -1f);

    // Called once per frame, after all Update functions have been called.
    void FixedUpdate()
    {
        // 1. Calculate the desired position
        // This is the target's position plus the defined offset.
        Vector3 desiredPosition = target.position + offset;

        // 2. Smoothly move towards the desired position
        // The 'Lerp' function moves from position A to position B over time (smoothSpeed).
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // 3. Apply the smoothed position to the camera's Transform
        transform.position = smoothedPosition;

        // Optional: Make the camera look at the target (Less common in 2D)
        // transform.LookAt(target);
    }
}
