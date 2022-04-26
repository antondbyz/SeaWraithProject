using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

[DefaultExecutionOrder(-1)]
public class SaveManager : Singleton<SaveManager>
{
    public static SaveData SaveData { get; private set; }
    private string SavePath => $"{Application.persistentDataPath}/save_data.save";

    public void NewGame()
    {
        File.Delete(SavePath);
        LoadGame();
    }

    private void SaveGame()
    {
        Debug.Log("save");
        SaveData data = new SaveData();
        BinaryFormatter formatter = new BinaryFormatter();
        using (FileStream stream = new FileStream(SavePath, FileMode.Create))
        {
            formatter.Serialize(stream, data);
        }
    }

    private void LoadGame()
    {
        Debug.Log("load");
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

    protected override void Awake()
    {
        base.Awake();
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