using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    public PlayerDatabase database;
    public PlayerData currentPlayer;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            database = SaveSystem.Load();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddNewPlayer(string playerName)
    {
        currentPlayer = new PlayerData(playerName, 0);
        database.players.Add(currentPlayer);
        SaveSystem.Save(database);
    }

    public void UpdateHighScore(int newScore)
    {
        if (currentPlayer != null && newScore > currentPlayer.highScore)
        {
            currentPlayer.highScore = newScore;
            SaveSystem.Save(database);
        }
    }
}
