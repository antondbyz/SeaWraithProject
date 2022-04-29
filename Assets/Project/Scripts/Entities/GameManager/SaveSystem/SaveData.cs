using System;

[Serializable]
public class SaveData
{
    public int BestScore { get; private set; }
    public int CrystalsAmount { get; private set; }
    public int CurrentSubmarineIndex { get; private set; }
    public bool[] SubmarinesPurchaseStatus { get; private set; }

    public void Initialize()
    {
        BestScore = PlayerProfile.BestScore;
        CrystalsAmount = PlayerProfile.CrystalsAmount;
        CurrentSubmarineIndex = SubmarinesManager.CurrentSubmarineIndex;
        SubmarinesPurchaseStatus = SubmarinesManager.SubmarinesPurchaseStatus;
    }
}