using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public static class FileHelper
{
    public static string GetDataPath(string path)
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
}
