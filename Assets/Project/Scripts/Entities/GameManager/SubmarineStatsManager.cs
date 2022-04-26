using UnityEngine;

public class SubmarineStatsManager : MonoBehaviour
{
    public static event System.Action CurrentStatsObjectChanged;
    public static SubmarineStatsObject[] StatsObjects { get; private set; }
    public static SubmarineStatsObject CurrentStatsObject => StatsObjects[CurrentObjectIndex];
    public static SubmarineStatsObject NextStatsObject
    {
        get
        {
            if (CurrentObjectIndex < StatsObjects.Length - 1)
            {
                return StatsObjects[CurrentObjectIndex + 1];
            }
            else return null;
        }
    }
    public static int CurrentObjectIndex { get; private set; }

    public static void UpgradeCurrentStatsObject() 
    {
        if(SaveManager.SaveData.CurrentSubmarineStatsIndex < (StatsObjects.Length - 1))
        {
            CurrentObjectIndex++;
            CurrentStatsObjectChanged?.Invoke();
        }
    }

    private void Awake()
    {
        CurrentObjectIndex = SaveManager.SaveData.CurrentSubmarineStatsIndex;
        StatsObjects = Resources.LoadAll<SubmarineStatsObject>("SubmarineObjects/SubmarineStats");
    }
}
