using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager _;
    [SerializeField] private bool _debugMode;
    public enum MainMenuButtons { Continue, newGame, howToPlay, scoreboard, settings, credits, quit };
    public enum HowToPlayButtons { back };
    public enum ScoreboardButtons { back };
    public enum SettingsButtons { back };
    public enum CreditsButtons { back };
    [SerializeField] GameObject _MainMenuContainer;
    [SerializeField] GameObject _SettingsMenuContainer;
    [SerializeField] GameObject _CreditsMenuContainer;
    [SerializeField] GameObject _HowToPlayMenuContainer;
    [SerializeField] GameObject _ScoreboardMenuContainer;
    [SerializeField] private string _sceneToLoadAfterClickingContinue;

    public void Awake()
    {
        if (_ == null)
        {
            _ = this;
        }
        else
        {
            Debug.LogError("There are more than 1 MainMainManager's in the scene");
        }
    }
    private void Start()
    {
        OpenMenu(_MainMenuContainer);
    }
    public void MainMenuButtonClicked(MainMenuButtons buttonClicked)
    {
        DebugMessage("Button Clicked: " + buttonClicked.ToString());
        switch (buttonClicked)
        {
            case MainMenuButtons.Continue:
                ContinueClicked();
                break;
            case MainMenuButtons.newGame:
                break;
            case MainMenuButtons.howToPlay:
                OpenHowToPlayMenu();
                break;
            case MainMenuButtons.scoreboard:
                OpenScoreboardMenu();
                break;
            case MainMenuButtons.settings:
                OpenSettingsMenu();
                break;
            case MainMenuButtons.credits:
                OpenCreditsMenu();
                break;
            case MainMenuButtons.quit:
                QuitGame();
                break;
            default:
                Debug.Log("Button clicked was not implemented in MainMenuButtonClicked() switchcase");
                break;
        }
    }


    public void ContinueClicked()
    {
        SceneManager.LoadScene(_sceneToLoadAfterClickingContinue);
    }

    public void SettingsButtonClicked(SettingsButtons buttonClicked)
    {
        switch(buttonClicked)
        {
            case SettingsButtons.back:
                BackToMainMenu();
                break;
        }
    }

    public void CreditsButtonClicked(CreditsButtons buttonClicked)
    {
        switch(buttonClicked)
        {
            case CreditsButtons.back:
                BackToMainMenu();
                break;
        }
    }
    
    public void ScoreboardButtonClicked(ScoreboardButtons buttonClicked)
    {
        switch(buttonClicked)
        {
            case ScoreboardButtons.back:
                BackToMainMenu();
                break;
        }
    }

    public void HowToPlayButtonClicked(HowToPlayButtons buttonClicked)
    {
        switch(buttonClicked)
        {
            case HowToPlayButtons.back:
                BackToMainMenu();
                break;
        }
    }


    public void OpenSettingsMenu()
    {
        OpenMenu(_SettingsMenuContainer);
    }
    
    public void OpenCreditsMenu()
    {
        OpenMenu(_CreditsMenuContainer);
    }

    public void OpenScoreboardMenu()
    {
        OpenMenu(_ScoreboardMenuContainer);
    }

    public void OpenHowToPlayMenu()
    {
        OpenMenu(_HowToPlayMenuContainer);
    }

    public void BackToMainMenu()
    {
        OpenMenu(_MainMenuContainer);
    }
    
    private void DebugMessage(string message)
    {
        if (_debugMode)
        {
            Debug.Log(message);
        }
    }


    public void OpenMenu(GameObject menuToOpen)
    {
        _MainMenuContainer.SetActive(menuToOpen == _MainMenuContainer);
        _SettingsMenuContainer.SetActive(menuToOpen == _SettingsMenuContainer);
        _CreditsMenuContainer.SetActive(menuToOpen == _CreditsMenuContainer);
        _HowToPlayMenuContainer.SetActive(menuToOpen == _HowToPlayMenuContainer);
        _ScoreboardMenuContainer.SetActive(menuToOpen == _ScoreboardMenuContainer);
    }
    
    public void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
