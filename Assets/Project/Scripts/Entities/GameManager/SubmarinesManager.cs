using UnityEngine;

public class SubmarinesManager : MonoBehaviour, IInitializableOnLoad
{
    public static event System.Action Changed;
    public static SubmarineObject[] SubmarineObjects { get; private set; }
    public static int CurrentSubmarineIndex { get; private set; }
    public static bool[] SubmarinesPurchaseStatus { get; private set; }
    public static SubmarineObject CurrentSubmarine => SubmarineObjects[CurrentSubmarineIndex];

    public static void SetCurrentSubmarineIndex(int newSubmarineIndex)
    {
        CurrentSubmarineIndex = newSubmarineIndex;
        Changed?.Invoke();
    }

    public static void MarkSubmarineAsBought(int submarineIndex) 
    {
        SubmarinesPurchaseStatus[submarineIndex] = true;
        Changed?.Invoke(); 
    }

    public static bool IsSubmarineBought(int submarineIndex) 
    {
        return SubmarinesPurchaseStatus[submarineIndex];
    }

    public void Initialize(SaveData initializationData)
    {
        SubmarineObjects = Resources.LoadAll<SubmarineObject>("SubmarineObjects");
        SubmarinesPurchaseStatus = new bool[SubmarineObjects.Length];
        if(SaveManager.IsFirstStart)
        {
            SubmarinesPurchaseStatus[0] = true; 
            CurrentSubmarineIndex = 0;
        }
        else
        {
            CurrentSubmarineIndex = initializationData.CurrentSubmarineIndex;
            initializationData.SubmarinesPurchaseStatus.CopyTo(SubmarinesPurchaseStatus, 0);
        }
    }
}
