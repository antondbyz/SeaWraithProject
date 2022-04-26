using UnityEngine;

public class SubmarinePaintsManager : MonoBehaviour
{
    public static event System.Action ItemsChanged;
    public static SubmarinePaintObject[] PaintObjects { get; private set; }
    public static SubmarinePaintObject CurrentPaintObject => PaintObjects[CurrentObjectIndex];
    public static int CurrentObjectIndex { get; private set; }
    public static bool[] ObjectsPurchaseStatus { get; private set; }

    public static void SetCurrentItem(PaintItem item)
    {
        CurrentObjectIndex = item.Index;
        ItemsChanged?.Invoke();
    }

    public static void MarkItemAsBought(PaintItem item)
    {
        ObjectsPurchaseStatus[item.Index] = true;
        ItemsChanged?.Invoke(); 
    }

    public static bool IsItemBought(PaintItem item) => ObjectsPurchaseStatus[item.Index];

    private void Awake()
    {
        CurrentObjectIndex = SaveManager.SaveData.CurrentSubmarinePaintIndex;
        ObjectsPurchaseStatus = SaveManager.SaveData.PaintsPurchaseStatus;
        PaintObjects = Resources.LoadAll<SubmarinePaintObject>("SubmarineObjects/SubmarinePaints");
        if(ObjectsPurchaseStatus == null)
        {
            ObjectsPurchaseStatus = new bool[PaintObjects.Length];
            ObjectsPurchaseStatus[0] = true;
        }
    }
}
