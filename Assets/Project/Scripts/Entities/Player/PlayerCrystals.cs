using TMPro;
using UnityEngine;

public class PlayerCrystals : MonoBehaviour
{
    public int CrystalsCollected
    {
        get => _crystalsCollected;
        private set
        {
            _crystalsCollected = value;
            _crystalsText.text = (PlayerProfile.CrystalsAmount + _crystalsCollected).ToString();
        }
    }
    [SerializeField] private TMP_Text _crystalsText;
    private int _crystalsCollected;

    public void CollectCrystal()
    {
        CrystalsCollected++;
    }

    private void Awake()
    {
        CrystalsCollected = 0;
    }
}
