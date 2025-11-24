using UnityEngine;

public class GravitySource : MonoBehaviour
{
    [Tooltip("The radius within which other objects will be affected by this gravity source.")]
    public float gravityRadius = 5f;

    [Tooltip("The strength of the gravitational pull.")]
    public float gravityForce = 50f;

    [Tooltip("The layer(s) of objects this gravity source will affect.")]
    public LayerMask affectedLayers;

    private void FixedUpdate()
    {
        // 1. Find all colliders within the gravity radius
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, gravityRadius, affectedLayers);

        // 2. Iterate through all found objects
        foreach (Collider2D hitCollider in hitColliders)
        {
            // Check if the hit object has a Rigidbody2D and isn't this object itself
            Rigidbody2D affectedRigidbody = hitCollider.GetComponent<Rigidbody2D>();

            if (affectedRigidbody != null && affectedRigidbody.gameObject != gameObject)
            {
                // Calculate the vector pointing from the affected object to the gravity source
                Vector2 gravityDirection = (Vector2)transform.position - affectedRigidbody.position;

                // Calculate the distance between the two objects
                float distance = gravityDirection.magnitude;

                // 3. Normalize the direction vector
                gravityDirection.Normalize();

                // 4. Calculate the pull force
                // We can optionally use an inverse square relationship (like real gravity), 
                // but a simpler linear pull is often easier for arcade-style games.

                // Simple Linear Force: Force remains constant regardless of distance
                // Vector2 pullForce = gravityDirection * gravityForce;

                // Inverse Square Force: Pull weakens as distance increases (more realistic)
                float pullMagnitude = gravityForce / Mathf.Max(1f, distance * distance);
                Vector2 pullForce = gravityDirection * pullMagnitude;

                // 5. Apply the force to the Rigidbody2D
                affectedRigidbody.AddForce(pullForce, ForceMode2D.Force);
            }
        }
    }

    // Optional: Draw the gravity radius in the editor for visualization
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, gravityRadius);
    }
}
