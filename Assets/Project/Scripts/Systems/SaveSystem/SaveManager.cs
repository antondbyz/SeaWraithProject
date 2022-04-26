using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[DefaultExecutionOrder(-1)]
public class SaveManager : MonoBehaviour
{
    public static SaveData SaveData { get; private set; }
    private string SavePath => $"{Application.persistentDataPath}/save_data.save";

    private void SaveGame()
    {
        SaveData data = new SaveData();
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(SavePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    private void LoadGame()
    {
        if(File.Exists(SavePath))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using(FileStream stream = new FileStream(SavePath, FileMode.Open))
            {
                SaveData = (SaveData)formatter.Deserialize(stream);
            }
        }
        else SaveData = new SaveData();
    }

    private void Awake()
    {
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