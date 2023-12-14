using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    private const string SaveFileName = "parkour-last-save.data";

    public void SaveGame(Scene scene)
    {
        string filePath = GetSaveFilePath();

        if (!File.Exists(filePath))
        {
            using (FileStream fs = File.Create(filePath)) { }
        }

        File.WriteAllText(filePath, scene.buildIndex.ToString());
    }

    public string LoadGame()
    {
        string filePath = GetSaveFilePath();

        if (File.Exists(filePath))
        {
            string id = File.ReadAllText(filePath);

            return id;
        }

        return "";
    }

    private string GetSaveFilePath()
    {
        return Path.Combine(Application.persistentDataPath, SaveFileName);
    }
}
