using UnityEngine;

public class RocketExhaustControls : MonoBehaviour
{
    public ParticleSystem particleEffect;

    [Tooltip("The rate of particles to emit when the key is held.")]
    public float emissionRate = 500f; // Set your desired rate in the Inspector

    private ParticleSystem.EmissionModule emission;

    void Start()
    {
        // 1. Get the Emission Module component once in Start() for efficiency
        if (particleEffect != null)
        {
            emission = particleEffect.emission;

            // 2. Ensure the emission starts at 0 (off)
            emission.rateOverTime = 0f;

            // 3. IMPORTANT: Make sure the particle system is always running!
            // This is the key to removing the delay.
            particleEffect.Play();
        }
    }

    void Update()
    {
        if (particleEffect == null) return;

        // Check if the Spacebar is held down
        if (Input.GetKey(KeyCode.Space))
        {
            // Set the emission rate to the desired value
            emission.rateOverTime = emissionRate;
        }
        else
        {
            // Set the emission rate to zero (instantly stops visible emission)
            emission.rateOverTime = 0f;
        }
    }
}
