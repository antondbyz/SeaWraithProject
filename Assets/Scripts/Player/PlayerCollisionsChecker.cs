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
        Interactable interactable = other.GetComponent<Interactable>();
        if(interactable != null)
        {
            switch (interactable.Type)
            {
                case InteractableType.Bomb:
                    _playerHealth.Health--;
                    break;
                
                case InteractableType.Armor:
                    _playerHealth.Health++;
                    break;

                case InteractableType.Coin:
                    _playerCoins.Coins++;
                    break;
            }
            Destroy(other.gameObject); 
        }
    }
}
