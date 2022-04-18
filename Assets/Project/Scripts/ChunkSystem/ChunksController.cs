using UnityEngine;

public class ChunksController : MonoBehaviour
{
    private float _offset;
    private Transform _lastChunk;
    
    public void OnChunkBecameInvisible(Transform chunk)
    {
        chunk.position = new Vector2(_lastChunk.position.x + _offset, chunk.position.y);
        _lastChunk = chunk;
    }

    private void Awake()
    {
        _lastChunk = transform.GetChild(transform.childCount - 1);
        _offset = _lastChunk.position.x / (transform.childCount - 1);
    }
}
