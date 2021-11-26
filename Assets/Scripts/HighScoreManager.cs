using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class HighScoreManager
{
    private static int maxScoreItems = int.MaxValue;
    private static string highScoreFilePath = "highscores.json";

    public static List<HighScoreItem> LoadScores()
    {
        string path = FileHelper.GetDataPath(highScoreFilePath);
        if (File.Exists(path))
        {
            Debug.Log("Reading high score file...");
            string jsonString = File.ReadAllText(path);
            Debug.Log("High score file read.");
            if (jsonString != null && jsonString.Length > 0)
            {
                return JsonUtility.FromJson<HighScoreList>(jsonString).scores;
            }
            else
            {
                return new List<HighScoreItem>();
            }
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
            Debug.Log($"Trying to save {scores.Count} high scores...");
            string path = FileHelper.GetDataPath(highScoreFilePath);
            string jsonString = JsonUtility.ToJson(new HighScoreList(scores));

            Debug.Log("Saving high score file...");
            File.WriteAllText(path, jsonString);
            Debug.Log("High score file saved.");
        }
        else
        {
            Debug.LogWarning("Empty score list not written.");
        }
    }

    public static void AddScoreToFile(int score, string name = "")
    {
        HighScoreItem newScore = new HighScoreItem(score, name);

        List<HighScoreItem> scores = LoadScores();
        if (scores.Count + 1 > maxScoreItems)
        {
            throw new System.NotImplementedException("High score trimming not supported.");
        }
        scores.Add(newScore);

        StoreScores(scores);
    }
}
