using UnityEngine;
using UnityEngine.SceneManagement;

public class Killbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
            // restart the scene (level)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
