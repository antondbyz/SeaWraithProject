using UnityEngine;

public class SubmarinePaintsManager : MonoBehaviour
{
    public static SubmarinePaintObject[] PaintObjects { get; private set; }
    public static bool[] BoughtObjects { get; private set; }
    public static int CurrentPaintObjectIndex { get; private set; }
    public static SubmarinePaintObject CurrentPaintObject => PaintObjects[CurrentPaintObjectIndex];

    private void Awake()
    {
        PaintObjects = Resources.LoadAll<SubmarinePaintObject>("SubmarineObjects/SubmarinePaints");
        if(BoughtObjects == null)
        {
            BoughtObjects = new bool[PaintObjects.Length];
            BoughtObjects[0] = true;
        }
    }
}
