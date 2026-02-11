using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenu;
    public string SceneName = "MainMenu";

    void Start()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            if (GameIsPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;

        SceneManager.LoadScene(SceneName);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;

        Debug.Log("Quitting game...");
        Application.Quit();
    }

    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
