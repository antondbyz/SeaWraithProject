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
            _crystalsText.text = _crystalsCollected.ToString();
        }
    }

    [SerializeField] private TMP_Text _crystalsText;

    private int _crystalsCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Crystal crystal = other.GetComponent<Crystal>();
        if(crystal != null)
        {
            CrystalsCollected++;
            crystal.Collect();
        }
    }
}
