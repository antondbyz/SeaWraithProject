using System;

[Serializable]
public class SaveData
{
    public static int BestScore { get; private set; }
    public static int CrystalsAmount { get; private set; }
    public static int CurrentSubmarineStatsIndex { get; private set; }
    public static int CurrentSubmarinePaintIndex { get; private set; }
    public static bool[] PaintsPurchaseStatus { get; private set; }

    public void UpdateData()
    {
        BestScore = PlayerProfile.BestScore;
        CrystalsAmount = PlayerProfile.CrystalsAmount;
        CurrentSubmarineStatsIndex = SubmarineStatsManager.CurrentObjectIndex;
        CurrentSubmarinePaintIndex = SubmarinePaintsManager.CurrentObjectIndex;
        PaintsPurchaseStatus = SubmarinePaintsManager.ObjectsPurchaseStatus;
    }
}