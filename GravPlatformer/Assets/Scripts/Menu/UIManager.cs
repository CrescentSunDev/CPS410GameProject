using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public string mainMenuScene = "MainMenu";

    public enum GameState
    {
        Playing,
        Paused,
        GameOver
    }

    public GameState CurrentState { get; private set; } = GameState.Playing;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);

        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        if (CurrentState == GameState.GameOver)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (CurrentState == GameState.Paused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // ---------------- PAUSE ----------------

    public void PauseGame()
    {
        CurrentState = GameState.Paused;

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        CurrentState = GameState.Playing;

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // ---------------- GAME OVER ----------------

    public void TriggerGameOver()
    {
        CurrentState = GameState.GameOver;

        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // ---------------- BUTTONS ----------------

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}