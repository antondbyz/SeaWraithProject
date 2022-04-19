using UnityEngine;

public class SubmarinePaintsManager : MonoBehaviour
{
    public static event System.Action ItemsChanged;
    public static SubmarinePaintObject[] PaintObjects { get; private set; }
    public static SubmarinePaintObject CurrentPaintObject => PaintObjects[CurrentPaintItemIndex];
    public static int CurrentPaintItemIndex { get; private set; }
    private static bool[] ItemsBoughtStatus;

    public static void SetCurrentItem(PaintItem item)
    {
        CurrentPaintItemIndex = item.Index;
        ItemsChanged?.Invoke();
    }

    public static void MarkItemAsBought(PaintItem item)
    {
        ItemsBoughtStatus[item.Index] = true;
        ItemsChanged?.Invoke();
    }

    public static bool IsItemBought(PaintItem item) => ItemsBoughtStatus[item.Index];

    private void Awake()
    {
        PaintObjects = Resources.LoadAll<SubmarinePaintObject>("SubmarineObjects/SubmarinePaints");
        if(ItemsBoughtStatus == null)
        {
            ItemsBoughtStatus = new bool[PaintObjects.Length];
            ItemsBoughtStatus[0] = true;
        }
    }
}
