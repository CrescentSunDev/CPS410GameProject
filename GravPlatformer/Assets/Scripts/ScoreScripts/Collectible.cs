using UnityEngine;

// add collider and mark as "Is Trigger" in the inspector

public class Collectible : MonoBehaviour
{

    [Tooltip("Score value of the collectible")]
    public int collectibleValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // NOTE: UPDATE SCORE HERE
            // call player script or game manager to update the score value

            // destroy object
            Destroy(gameObject);

            ScoreManager.instance.AddPoints(collectibleValue);

        }
    }
}
