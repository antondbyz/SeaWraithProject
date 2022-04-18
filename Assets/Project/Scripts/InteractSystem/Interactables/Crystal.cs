using UnityEngine;

public class Crystal : MonoBehaviour, IInteractable, ISpawnable
{
    public InteractableType Type => InteractableType.Crystal;

    public void Interact()
    {
        Disappear();
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}
