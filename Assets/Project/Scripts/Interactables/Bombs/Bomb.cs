using UnityEngine;

public abstract class Bomb : MonoBehaviour, IInteractable, ISpawnable
{
    [SerializeField] private GameObject _explosionEffect;

    public void Interact(GameObject interactor)
    {
        PlayerHealth playerHealth = interactor.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage();
            Instantiate(_explosionEffect, transform.position, Quaternion.identity);
            Disappear();
        }
    }

    public void Spawn(Vector2 position)
    {
        transform.position = position;
        Initialize();
    }

    public abstract void Disappear();

    protected abstract void Initialize();
}
