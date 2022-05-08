using System.IO;
using UnityEditor;

public class SaveManagerEditor : Editor
{
    
    [MenuItem("SaveManager/RemoveSaveFile")]
    private static void RemoveSaveFile()
    {
        File.Delete(SaveManager.SavePath);
    }
}
