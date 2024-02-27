using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager
{
    private const string dataFolder = "Data"; 
    public static void SaveData(string key, string data)
    {
        string folderPath = Path.Combine(Application.persistentDataPath, dataFolder);

        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        string filePath = Path.Combine(folderPath, key + ".json");
        try
        {
            File.WriteAllText(filePath, data);
            Debug.Log("Data saved successfully: " + filePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save data: " + e.Message);
        }
    }
    public static string LoadData(string key)
    {
        string filePath = Path.Combine(Application.persistentDataPath, dataFolder, key + ".json");
        if (File.Exists(filePath))
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                return jsonData;
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to load data: " + e.Message);
                return null;
            }
        }
        else
        {
            Debug.LogWarning("Data file not found: " + filePath);
            return null;
        }
    }
}
