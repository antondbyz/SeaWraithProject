using UnityEngine;

public class SubmarineStatsManager : MonoBehaviour, IInitializableOnLoad
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
        if(CurrentObjectIndex < (StatsObjects.Length - 1))
        {
            CurrentObjectIndex++;
            CurrentStatsObjectChanged?.Invoke();
        }
    }

    public void Initialize(SaveData initializationData)
    {
        CurrentObjectIndex = initializationData.CurrentSubmarineStatsIndex;
    }

    private void Awake()
    {
        StatsObjects = Resources.LoadAll<SubmarineStatsObject>("SubmarineObjects/SubmarineStats");
    }
}
