using UnityEngine;

public class PlayerProfile : MonoBehaviour, IInitializableOnLoad
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
    [SerializeField] private int _increaseStartCrystalsAmount;
    
    public void Initialize(SaveData initializationData)
    {
        _bestScore = initializationData.BestScore;
        _crystalsAmount = initializationData.CrystalsAmount;
        #if UNITY_EDITOR
        CrystalsAmount += _increaseStartCrystalsAmount;
        #endif
    }
}
