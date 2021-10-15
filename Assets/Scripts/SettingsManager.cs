using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class SettingsManager
{
    private static string settingsFilePath = "settings.json";

    public static SettingsObject LoadSettings()
    {
        string path = FileHelper.GetDataPath(settingsFilePath);
        if (File.Exists(path))
        {
            Debug.Log("Reading settings file...");
            string jsonString = File.ReadAllText(path);
            Debug.Log("Settings file read.");
            return JsonUtility.FromJson<SettingsObject>(jsonString);
        }
        else
        {
            Debug.LogWarning("Settings file not found. Returning default settings");
            return new SettingsObject();
        }
    }

    public static void SaveSettings(SettingsObject settings)
    {
        string path = FileHelper.GetDataPath(settingsFilePath);
        Debug.Log("Saving settings to: " + path);
        string jsonString = JsonUtility.ToJson(settings);
        File.WriteAllText(path, jsonString);
        Debug.Log("Saved settings to: " + path);
    }

    public static string GetPlayerName()
    {
        return LoadSettings().playerName;
    }
}
