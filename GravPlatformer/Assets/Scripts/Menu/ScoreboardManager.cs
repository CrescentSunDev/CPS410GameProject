using UnityEngine;
using TMPro;

public class ScoreboardManager : MonoBehaviour
{
    public Transform contentParent;      
    public GameObject ScoreRow;    

    void OnEnable()
    {
        RefreshScoreboard();
    }

    public void RefreshScoreboard()
    {
        // Clear previous rows
        foreach (Transform child in contentParent)
            Destroy(child.gameObject);

        // Load all players
        PlayerDatabase db = SaveSystem.Load();

        // Sort by score (high → low)
        db.players.Sort((a, b) => b.highScore.CompareTo(a.highScore));

        // Create a row for each player
        foreach (PlayerData data in db.players)
        {
            GameObject row = Instantiate(ScoreRow, contentParent);

            TMP_Text[] texts = row.GetComponentsInChildren<TMP_Text>();
            texts[0].text = data.playerName;
            texts[1].text = data.highScore.ToString();
        }
    }
}
