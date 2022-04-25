using UnityEngine;

[DefaultExecutionOrder(-1)]
public class SaveManager : MonoBehaviour
{
    private string SavePath => $"{Application.persistentDataPath}/saves/save_data.save";

    private void SaveToFile(object data)
    {
        
    }

    private object LoadFromFile()
    {
        return null;
    }

    private void Awake()
    {
        SaveData loadedData = (SaveData)LoadFromFile();
    }

    private void OnApplicationFocus(bool focusStatus)
    {
        SaveData data = new SaveData();
        data.UpdateData();
        if(!focusStatus) 
        {
            SaveToFile(data);
        }
    }
}