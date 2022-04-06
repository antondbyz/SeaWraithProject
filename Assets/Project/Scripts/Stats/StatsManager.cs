using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public static event System.Action CrystalsChanged;

    public static int BestScore
    {
        get => _bestScore;
        set
        {
            if (value > _bestScore) _bestScore = value;
        }
    }
    public static int CrystalsAmount 
    { 
        get => _crystalsAmount;
        set
        {
            int oldValue = _crystalsAmount;
            _crystalsAmount = value;
            if (oldValue != _crystalsAmount) CrystalsChanged?.Invoke();
        }
    }
    public static SubmarineStats SubmarineStats => _submarineStats;

    private static int _bestScore;
    private static int _crystalsAmount;
    private static SubmarineStats _submarineStats;

    private void Awake()
    {
        UpdateSubmarineStats();
    }

    private void OnEnable()
    {
        SubmarineItemsManager.CurrentSubmarineChanged += UpdateSubmarineStats;
    }

    private void OnDisable()
    {
        SubmarineItemsManager.CurrentSubmarineChanged -= UpdateSubmarineStats;
    }

    private void UpdateSubmarineStats()
    {
        _submarineStats = SubmarineItemsManager.CurrentSubmarineItem.SubmarineStats;
    }
}
