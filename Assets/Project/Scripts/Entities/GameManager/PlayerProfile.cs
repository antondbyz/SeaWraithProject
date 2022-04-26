using UnityEngine;

public class PlayerProfile : MonoBehaviour
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
            if(value != _crystalsAmount && value >= 0)
            {
                _crystalsAmount = value;
                CrystalsChanged?.Invoke();
            }
        }
    }
    private static int _bestScore;
    private static int _crystalsAmount;
    [SerializeField] private bool _setCustomCrystalsAmount;
    [SerializeField] private int _customCrystalsAmount;

    private void Awake()
    {
        _bestScore = SaveManager.SaveData.BestScore;
        _crystalsAmount = SaveManager.SaveData.CrystalsAmount;
        if(_setCustomCrystalsAmount) CrystalsAmount = _customCrystalsAmount;
    }
}
