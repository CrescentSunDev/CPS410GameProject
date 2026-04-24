using UnityEngine;

// add collider and mark as "Is Trigger" in the inspector

public class Collectible : MonoBehaviour
{

    [Tooltip("Score value of the collectible")]
    public int collectibleValue = 1;
    public float bobDistance = 0.15f;
    public float bobSpeed = 5f;
    private Vector2 startPosition;
    private float phaseShift;


    void Start()
    {
        startPosition = transform.position;
        phaseShift = Random.Range(0f, 2 * Mathf.PI);
    }
    void Update()
    {

        Bob();

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the colliding object is the player
        if (other.CompareTag("Player"))
        {

            // destroy object
            Destroy(gameObject);

            // play sound effect
            SoundEffectManager.Play("Collectible");

            // update score in ScoreManager
            ScoreManager.instance.AddPoints(collectibleValue);

        }
    }

    private void Bob()
    {
            float yPos = Mathf.Sin(Time.time * bobSpeed + phaseShift) * bobDistance + startPosition.y;
            transform.position = new Vector2(transform.position.x, yPos);
    }

}
