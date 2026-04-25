using UnityEngine;

public class GameOver : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kill"))
        {
            gameObject.SetActive(false);
            UIManager.Instance.TriggerGameOver();
        }
    }
}