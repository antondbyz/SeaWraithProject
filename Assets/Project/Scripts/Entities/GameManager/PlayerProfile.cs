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
    [SerializeField] private int _startCrystalsAmount;

    private void Awake()
    {
        _bestScore = SaveData.BestScore;
        _crystalsAmount = SaveData.CrystalsAmount;
        CrystalsAmount = _startCrystalsAmount;
    }
}
