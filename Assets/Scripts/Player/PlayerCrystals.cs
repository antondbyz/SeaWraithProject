using TMPro;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerCrystals : MonoBehaviour
{
    [SerializeField] private TMP_Text _crystalsText;

    public int CrystalsAmount
    {
        get => _crystalsAmount;
        private set
        {
            _crystalsAmount = value;
            _crystalsText.text = _crystalsAmount.ToString();
        }
    }

    private int _crystalsAmount;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_playerHealth.IsAlive)
        {
            Crystal crystal = other.GetComponent<Crystal>();
            if(crystal != null)
            {
                CrystalsAmount++;
                crystal.Collect();
            }
        }
    }
}
