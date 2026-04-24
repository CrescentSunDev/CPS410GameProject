using UnityEditorInternal;
using UnityEngine;

public class FallingIntro : MonoBehaviour
{
    [Header("Positions")]
    public Transform start;
    public Transform stop;
    public Transform player;
    private Vector2 startPos, stopPos, playerPos;
    private float separation = 0f;
    [Header("Rotation Settings")]
    [Tooltip("Number of spins the player performs before reaching the stopping point")]
    public int nSpins = 0;
    [Tooltip("Rotation speed in deg/s")]
    public float rotationSpeed = 0f;
    [Header("Audio")]
    public AudioClip hitSound;
    private AudioSource audioSource;

    void Start()
    {
        // get positions for starting and stopping points
        startPos = start.position;
        stopPos = stop.position;
        player.position = startPos;
        separation = startPos.y - stopPos.y;

        // get audio source
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // calculate how much the player will be displaced
        float displacementSpeed = separation * rotationSpeed / (360 * nSpins);

        // if displacement exceeds stop position, end rotation.
        if(player.position.y - displacementSpeed * Time.deltaTime < stopPos.y)
        {
            // set player to upright as backup
            player.eulerAngles = new Vector2(0f, 0f);

            // play sound effect
            if(audioSource != null && hitSound != null)
            {
                audioSource.PlayOneShot(hitSound);
            }
            
            // destroy script
            Destroy(this);
        } else
        {
            player.position = new Vector2(player.position.x, player.position.y - displacementSpeed * Time.deltaTime);
            player.eulerAngles = new Vector3(0f, 0f, player.eulerAngles.z - rotationSpeed * Time.deltaTime);
        }
            
    }

}
