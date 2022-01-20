using UnityEngine;

public class GroundChunk : MonoBehaviour
{
    private static float Offset;
    private static Transform LastChunk;

    private void Start()
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
