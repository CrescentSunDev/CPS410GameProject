using UnityEngine;
using UnityEngine.UI;

public class TimeScore : MonoBehaviour
{
    public float score;              // Current score
    public float multiplier = 1f;    // Score multiplier (optional)
    public Text scoreText;           // UI Text to display score

    private bool isPlaying = true;

    void Update()
    {
        if (isPlaying)
        {
            // Increase score based on time
            score += Time.deltaTime * multiplier;

            // Update UI (rounded score)
            scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
        }
    }

    // Call this when the game ends
    public void StopScoring()
    {
        isPlaying = false;
    }
}