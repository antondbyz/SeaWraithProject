using UnityEngine;
using TMPro;

public class PlayerCoins : MonoBehaviour
{
    public int Coins
    {
        get => _coins;
        set
        {
            _coins = value;
            _coinsText.text = _coins.ToString();
        }
    }

    [SerializeField] private TMP_Text _coinsText = null;

    private int _coins;
}
