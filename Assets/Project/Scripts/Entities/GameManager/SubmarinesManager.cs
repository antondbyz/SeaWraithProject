using UnityEngine;

public class SubmarinesManager : MonoBehaviour, IInitializableOnLoad
{
    public static event System.Action Changed;
    public static SubmarineObject[] SubmarineObjects { get; private set; }
    public static SubmarineObject CurrentSubmarine => SubmarineObjects[CurrentSubmarineIndex];
    public static int CurrentSubmarineIndex { get; private set; }
    public static bool[] SubmarinesPurchaseStatus { get; private set; }

    public static void SetCurrentItem(SubmarineItem item)
    {
        CurrentSubmarineIndex = item.Index;
        Changed?.Invoke();
    }

    public static void MarkItemAsBought(SubmarineItem item)
    {
        SubmarinesPurchaseStatus[item.Index] = true;
        Changed?.Invoke(); 
    }

    public static bool IsItemBought(SubmarineItem item) => SubmarinesPurchaseStatus[item.Index];

    public void Initialize(SaveData initializationData)
    {
        SubmarineObjects = Resources.LoadAll<SubmarineObject>("SubmarineObjects");
        CurrentSubmarineIndex = initializationData.CurrentSubmarineIndex;
        SubmarinesPurchaseStatus = initializationData.SubmarinesPurchaseStatus;
        if(SubmarinesPurchaseStatus == null)
        {
            SubmarinesPurchaseStatus = new bool[SubmarineObjects.Length];
            SubmarinesPurchaseStatus[0] = true; 
        }
    }
}
