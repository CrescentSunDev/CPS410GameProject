using UnityEngine;
using UnityEngine.UI;

public class NewPlayerUI : MonoBehaviour
{
    public InputField playerNameInput;
    public Button startGameButton;

    private void Start()
    {
        startGameButton.onClick.AddListener(OnStartGameClicked);
    }

    void OnStartGameClicked()
    {
        string playerName = playerNameInput.text.Trim();
        if (!string.IsNullOrEmpty(playerName))
        {
            PlayerManager.instance.AddNewPlayer(playerName);

            // Switch canvas here
            gameObject.SetActive(false); // Hide this canvas
            // mainGameCanvas.SetActive(true); // Show the game canvas
        }
    }
}
