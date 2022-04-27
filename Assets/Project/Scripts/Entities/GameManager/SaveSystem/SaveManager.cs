using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[DefaultExecutionOrder(-1)]
public class SaveManager : MonoBehaviour
{
    private static string SavePath => $"{Application.persistentDataPath}/save_data.save";
    private static IInitializableOnLoad[] _initializables;

    public static void NewGame()
    {
        File.Delete(SavePath);
        LoadGame();
    }

    private static void SaveGame()
    {
        SaveData data = new SaveData();
        data.Initialize();
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(SavePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    private static void LoadGame()
    {
        SaveData loadedData = new SaveData();
        if(File.Exists(SavePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream stream = new FileStream(SavePath, FileMode.Open))
            {
                loadedData = (SaveData)formatter.Deserialize(stream);
            }
        }
        for(int i = 0; i < _initializables.Length; i++)
        {
            _initializables[i].Initialize(loadedData);
        }
    }

    private void Awake()
    {
        _initializables = GetComponents<IInitializableOnLoad>();
        LoadGame();
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        if(!focusStatus) 
        {
            SaveGame();
        }
    }
}