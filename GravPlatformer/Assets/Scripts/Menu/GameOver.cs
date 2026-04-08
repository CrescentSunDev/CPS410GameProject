using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class GaveOver : MonoBehaviour
{
    public GameObject GameOverMenu;
    public string SceneName = "MainMenu";
    public bool isGameOver = false;

    void Start()
    {
        GameOverMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Kill")
        {
            GameOver();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    void GameOver()
    {
        GameOverMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(gameObject);
    }
}
