using System;

[Serializable]
public class SaveData
{
    public int BestScore { get; private set; }
    public int CrystalsAmount { get; private set; }
    public int CurrentSubmarineIndex { get; private set; }
    public bool[] SubmarinesPurchaseStatus { get; private set; }
    public SettingsData Settings { get; private set; } = new SettingsData(1, 1);
    public bool IsPremiumPurchased { get; private set; }
    public int CurrentLanguageIndex { get; private set; }

    public void Initialize()
    {
        BestScore = PlayerProfile.BestScore;
        CrystalsAmount = PlayerProfile.CrystalsAmount;
        CurrentSubmarineIndex = SubmarinesManager.CurrentSubmarineIndex;
        SubmarinesPurchaseStatus = SubmarinesManager.SubmarinesPurchaseStatus;
        Settings = SettingsManager.Settings;
        IsPremiumPurchased = IAPManager.IsPremiumPurchased;
        CurrentLanguageIndex = LocalesManager.CurrentLanguageIndex;
    }
}