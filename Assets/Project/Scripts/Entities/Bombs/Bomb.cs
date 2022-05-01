using UnityEngine;

public abstract class Bomb : MonoBehaviour, IInteractable, ISpawnable
{
    public InteractableType Type => InteractableType.Bomb;
    [SerializeField] private GameObject _explosionEffect;

    public void Interact()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Disappear();
    }

    public void Spawn(Vector2 position)
    {
        transform.position = position;
        Initialize();
    }

    public abstract void Disappear();

    protected abstract void Initialize();
}
