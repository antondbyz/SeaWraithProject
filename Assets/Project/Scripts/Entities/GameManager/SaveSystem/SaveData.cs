using System;

[Serializable]
public class SaveData
{
    public int BestScore { get; private set; }
    public int CrystalsAmount { get; private set; }
    public int CurrentSubmarineStatsIndex { get; private set; }
    public int CurrentSubmarinePaintIndex { get; private set; }
    public bool[] PaintsPurchaseStatus { get; private set; }

    public void Initialize()
    {
        BestScore = PlayerProfile.BestScore;
        CrystalsAmount = PlayerProfile.CrystalsAmount;
        CurrentSubmarineStatsIndex = SubmarineStatsManager.CurrentObjectIndex;
        CurrentSubmarinePaintIndex = SubmarinePaintsManager.CurrentObjectIndex;
        PaintsPurchaseStatus = SubmarinePaintsManager.ObjectsPurchaseStatus;
    }
}