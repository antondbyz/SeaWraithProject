using UnityEngine;

public class Crystal : MonoBehaviour, IInteractable, ISpawnable
{
    public static event System.Action Collected;

    public void Interact()
    {
        Collected?.Invoke();
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
