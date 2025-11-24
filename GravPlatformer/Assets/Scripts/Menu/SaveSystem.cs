using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static string filePath = Application.persistentDataPath + "/players.json";

    public static void Save(PlayerDatabase database)
    {
        string json = JsonUtility.ToJson(database, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Saved to: " + filePath);
    }

    public static PlayerDatabase Load()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            PlayerDatabase database = JsonUtility.FromJson<PlayerDatabase>(json);
            return database;
        }
        else
        {
            Debug.Log("No save file found. Creating new database.");
            return new PlayerDatabase();
        }
    }
}
