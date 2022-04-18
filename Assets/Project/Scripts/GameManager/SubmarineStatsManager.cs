using UnityEngine;

public class SubmarineStatsManager : MonoBehaviour
{
    public static event System.Action CurrentStatsObjectChanged;
    public static SubmarineStatsObject[] StatsObjects { get; private set; }
    public static int CurrentStatsObjectIndex { get; private set; }
    public static SubmarineStatsObject CurrentStatsObject => StatsObjects[CurrentStatsObjectIndex];
    public static SubmarineStatsObject NextStatsObject
    {
        get
        {
            if (CurrentStatsObjectIndex < StatsObjects.Length - 1)
            {
                return StatsObjects[CurrentStatsObjectIndex + 1];
            }
            else return null;
        }
    }

    public static void UpgradeCurrentStatsObject() 
    {
        if(CurrentStatsObjectIndex < (StatsObjects.Length - 1))
        {
            CurrentStatsObjectIndex++;
            CurrentStatsObjectChanged?.Invoke();
        }
    }

    private void Awake()
    {
        StatsObjects = Resources.LoadAll<SubmarineStatsObject>("SubmarineObjects/SubmarineStats");
    }
}
