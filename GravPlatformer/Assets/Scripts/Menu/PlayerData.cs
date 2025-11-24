using System;

[Serializable]
public class PlayerData
{
    public string playerName;
    public int highScore;

    public PlayerData(string name, int score)
    {
        playerName = name;
        highScore = score;
    }
}