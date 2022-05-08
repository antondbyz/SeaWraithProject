using TMPro;
using UnityEngine;

public class PlayerCrystals : MonoBehaviour
{
    public event System.Action CrystalsChanged;
    public int CrystalsCollected
    {
        get => _crystalsCollected;
        private set
        {
            _crystalsCollected = value;
            _crystalsText.text = (PlayerProfile.CrystalsAmount + _crystalsCollected).ToString();
            CrystalsChanged?.Invoke();
        }
    }
    [SerializeField] private TMP_Text _crystalsText;
    private int _crystalsCollected;

    public void DoubleCrystals() => CrystalsCollected *= 2;

    public void CollectCrystal() => CrystalsCollected++;

    private void Awake()
    {
        CrystalsCollected = 0;
    }

    private void OnEnable()
    {
        RewardCrystalsAdController.EarnedReward += DoubleCrystals;
    }

    private void OnDisable()
    {
        RewardCrystalsAdController.EarnedReward -= DoubleCrystals;
    }
}
