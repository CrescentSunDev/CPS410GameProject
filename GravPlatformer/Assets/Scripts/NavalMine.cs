using UnityEngine;
using UnityEngine.Android;
using UnityEngine.SceneManagement;

public class NavalMine : MonoBehaviour
{

    [Tooltip("Determines if the object can be triggered by colliding with the environment")]
    public bool triggerOnEnvironment = false;
    private bool explosionTriggered = false;

    public ParticleSystem particleSmoke;
    public ParticleSystem particleFire;
    private CircleCollider2D killzone;
    public Renderer mineRenderer;

    //private ParticleSystem.EmissionModule emissionSmoke;
    //private ParticleSystem.EmissionModule emissionFire;

    private float emissionRate = 500f;
    public float explosionTime = 5f;
    public float bobDistance = 0.5f;
    public float bobSpeed = 1f;
    private Vector2 startPosition;
    private float phaseShift;
    void Start()
    {
        killzone = GetComponentInParent<CircleCollider2D>();
        startPosition = transform.position;
        phaseShift = Random.Range(0f, 2 * Mathf.PI);
    }
    void Update()
    {

        Explode();
        Bob();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if the colliding object is the player
        if (other.CompareTag("Player") && !explosionTriggered)
        {
            // restart the scene (level)
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            explosionTriggered = true;

        } else if(other.CompareTag("Environment") && triggerOnEnvironment && !explosionTriggered)
        {
            // restart the scene (level)
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            explosionTriggered = true;

        }

        if (other.CompareTag("Player") && explosionTriggered)
        {
            Debug.Log("Player in collision. Add code to kill player.");
        }

    }

    private void Explode()
    {

        ParticleSystem.EmissionModule emissionSmoke = particleSmoke.emission;
        ParticleSystem.EmissionModule emissionFire = particleFire.emission;

        if (explosionTriggered)
        {
            // create kill sphere
            killzone.radius = 5f;

            // make the mine invisible when exploded
            Color color = mineRenderer.material.color;
            color.a = 0f;
            mineRenderer.material.color = color;

            emissionSmoke.rateOverTime = emissionRate;
            emissionFire.rateOverTime = emissionRate;
            particleSmoke.Play();
            particleFire.Play();
            explosionTime -= Time.deltaTime;

            // delete mine when timer is out
            if(explosionTime <= 0)
            {
                Destroy(gameObject);
            }
            // stop playing particle effects when explosion ending
            if(explosionTime <= 1)
            {
                particleSmoke.Stop();
                particleFire.Stop();
            }
        } else
        {
            emissionSmoke.rateOverTime = 0f;
            emissionSmoke.rateOverTime = 0f;
        }
            //Destroy(gameObject);

    }

    private void Bob()
    {
        if(!explosionTriggered)
        {
            float yPos = Mathf.Sin(Time.time * bobSpeed + phaseShift) * bobDistance + startPosition.y;
            transform.position = new Vector2(transform.position.x, yPos);
        }
    }

}
