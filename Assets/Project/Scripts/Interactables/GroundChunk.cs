using UnityEngine;

public class GroundChunk : MonoBehaviour, IInteractable
{
    private static float Offset;
    private static Transform LastChunk;

    public void Interact(GameObject interactor)
    {
        PlayerHealth playerHealth = interactor.GetComponent<PlayerHealth>();
        if(playerHealth != null)
        {
            playerHealth.Die();
        }
    }

    private void Awake()
    {
        if(transform.GetSiblingIndex() == transform.parent.childCount - 1)
        {
            LastChunk = transform;
            Offset = transform.position.x / (transform.parent.childCount - 1);
        }
    }

    private void OnBecameInvisible()
    {
        transform.position = new Vector2(LastChunk.position.x + Offset, transform.position.y);
        LastChunk = transform;
    }
}
