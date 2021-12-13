using UnityEngine;

public class Interactable : MonoBehaviour
{
    public InteractableType Type => _type;

    [SerializeField] private InteractableType _type = InteractableType.Bomb;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

public enum InteractableType
{
    Bomb, Armor, Coin
}