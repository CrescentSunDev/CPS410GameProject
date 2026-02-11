using UnityEngine;
using UnityEngine.UI;

public class HighScoreUI : MonoBehaviour
{
    public Text highScoreText;

    private void OnEnable()
    {
        DisplayHighScores();
    }

    void DisplayHighScores()
    {
        var players = PlayerManager.instance.database.players;
        players.Sort((a, b) => b.highScore.CompareTo(a.highScore)); // Descending order

        highScoreText.text = "High Scores:\n";
        foreach (var player in players)
        {
            highScoreText.text += $"{player.playerName}: {player.highScore}\n";
        }
    }
}
