using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager
{
    private const string dataFilePath = "data.json";

    [System.Serializable]
    private class DataContainer
    {
        public string key;
        public string data;
    }

    public static void SaveData(string key, string data)
    {
        string filePath = Path.Combine(Application.persistentDataPath, dataFilePath);

        try
        {
            DataContainer container = new DataContainer();
            container.key = key;
            container.data = data;
            string jsonData = JsonUtility.ToJson(container);

            File.WriteAllText(filePath, jsonData);
            Debug.Log("Data saved successfully.");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save data: " + e.Message);
        }
    }
    public static string LoadData(string key)
    {
        string filePath = Path.Combine(Application.persistentDataPath, dataFilePath);

        if (File.Exists(filePath))
        {
            try
            {
                string jsonData = File.ReadAllText(filePath);
                DataContainer container = JsonUtility.FromJson<DataContainer>(jsonData);
                if (container != null && container.key == key)
                {
                    return container.data;
                }
                else
                {
                    Debug.LogWarning("Key '" + key + "' not found in data file.");
                    return null;
                }
            }
            catch (System.Exception e)
            {
                Debug.LogError("Failed to load data: " + e.Message);
                return null;
            }
        }
        else
        {
            Debug.LogWarning("Data file not found.");
            return null;
        }
    }
}
