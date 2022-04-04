using UnityEngine;

[RequireComponent(typeof(PlayerHealth), typeof(PlayerCrystals))]
public class PlayerInteractor : MonoBehaviour
{
    private PlayerHealth _health;
    private PlayerCrystals _crystals;

    private void Awake()
    {
        _health = GetComponent<PlayerHealth>();
        _crystals = GetComponent<PlayerCrystals>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable != null)
        {
            interactable.Interact();
            switch(interactable.Type)
            {
                case InteractableType.Bomb:
                    _health.TakeDamage();
                    break;
                case InteractableType.Crystal:
                    _crystals.CollectCrystal();
                    break;
            }
        }
        else if(other.CompareTag("Ground"))
        {
            _health.Die();
        }
    }
}
