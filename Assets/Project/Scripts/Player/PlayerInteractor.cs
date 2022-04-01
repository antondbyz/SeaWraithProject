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

    private void OnEnable()
    {
        Bomb.Exploded += _health.TakeDamage;
        Crystal.Collected += _crystals.CollectCrystal;
    }

    private void OnDisable()
    {
        Bomb.Exploded -= _health.TakeDamage;
        Crystal.Collected -= _crystals.CollectCrystal;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IInteractable interactable = other.GetComponent<IInteractable>();
        if(interactable != null)
        {
            interactable.Interact();
        }
        else if(other.CompareTag("Ground"))
        {
            _health.Die();
        }
    }
}
