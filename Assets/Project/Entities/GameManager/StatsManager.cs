using UnityEngine;

public class StatsManager : Singleton<StatsManager>
{
    public event System.Action CrystalsChanged;

    public int CrystalsAmount 
    { 
        get => _crystalsAmount;
        private set
        {
            int oldValue = _crystalsAmount;
            _crystalsAmount = value;
            if (oldValue != _crystalsAmount) CrystalsChanged?.Invoke();
        }
    }
    public int MaxScore { get; private set; }

    private int _crystalsAmount;

    public void UpdateStats(int collectedCrystals, int score)
    {
        CrystalsAmount += collectedCrystals;
        if (score > MaxScore) MaxScore = score;
    }
}
