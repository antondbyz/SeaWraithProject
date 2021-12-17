using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(PlayerCoins))]
public class PlayerCollisionsChecker : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    private PlayerCoins _playerCoins;

    private void Awake() 
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _playerCoins = GetComponent<PlayerCoins>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bomb"))
        {
            _playerHealth.Health--;
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Armor"))
        {
            _playerHealth.Health++;
            Destroy(other.gameObject);
        }
        else if(other.CompareTag("Coin"))
        {
            _playerCoins.Coins++;
            Destroy(other.gameObject);
        }
    }
}
