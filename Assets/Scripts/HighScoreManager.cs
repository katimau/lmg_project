using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class HighScoreManager
{
    public static int maxScoreItems = int.MaxValue;
    public static string relativeFilePath = "highscores.json";

    private static string GetDataPath(string path)
    {
        string basePath = Path.GetFullPath(Application.persistentDataPath);
        string absolutePath = Path.GetFullPath(Path.Combine(basePath, path));

        // Check that path points inside the folder given by Application.persistentDataPath
        if (!absolutePath.StartsWith(basePath))
        {
            throw new System.ArgumentException("Path is not valid.");
        }
        return absolutePath;
    }

    public static List<HighScoreItem> LoadScores()
    {
        //string path = Path.Combine(Application.persistentDataPath, relativeFilePath);
        string path = GetDataPath(relativeFilePath);
        if (File.Exists(path))
        {
            Debug.Log("Reading high score file...");
            string jsonString = File.ReadAllText(path);
            Debug.Log("High score file read.");
            return JsonUtility.FromJson<List<HighScoreItem>>(jsonString);
        }
        else
        {
            Debug.LogWarning("High score file not found. Returning no scores.");
            return new List<HighScoreItem>();
        }
    }

    private static void StoreScores(List<HighScoreItem> scores)
    {
        if (scores.Count != 0)
        {
            //string path = Path.Combine(Application.persistentDataPath, relativeFilePath);
            string path = GetDataPath(relativeFilePath);
            string jsonString = JsonUtility.ToJson(scores);
            File.WriteAllText(path, jsonString);
        }
        else
        {
            Debug.LogWarning("Empty score list not written.");
        }
    }

    public static void AddScoreToFile(int score, string name = "")
    {
        HighScoreItem newScore = new HighScoreItem(score, System.DateTime.Now, name);

        List<HighScoreItem> scores = LoadScores();
        if (scores.Count + 1 > maxScoreItems)
        {
            throw new System.NotImplementedException("High score trimming not supported.");
        }
        scores.Add(newScore);

        StoreScores(scores);
    }
}
