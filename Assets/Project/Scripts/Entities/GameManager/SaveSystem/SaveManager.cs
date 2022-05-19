using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public static bool IsFirstStart { get; private set; }
    public static string SavePath => $"{Application.persistentDataPath}/save_data.save";
    private IInitializableOnLoad[] _initializables;

    private void Awake()
    {
        _initializables = GetComponents<IInitializableOnLoad>();
        IsFirstStart = !File.Exists(SavePath);
        Debug.Log(IsFirstStart);
        LoadGame();
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        if(!focusStatus) 
        {
            SaveGame();
        }
    }

    private void SaveGame()
    {
        SaveData data = new SaveData();
        data.Initialize();
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(SavePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    private void LoadGame()
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
}