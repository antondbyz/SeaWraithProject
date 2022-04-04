using UnityEngine;

public class ChunksController : MonoBehaviour
{
    private float _offset;
    private Transform _lastChunk;
    private Chunk[] _childChunks;

    public void OnChunkBecameInvisible(Transform chunk)
    {
        chunk.position = new Vector2(_lastChunk.position.x + _offset, chunk.position.y);
        _lastChunk = chunk;
    }

    private void Awake()
    {
        _childChunks = transform.GetComponentsInChildren<Chunk>();
        _lastChunk = transform.GetChild(transform.childCount - 1);
        _offset = _lastChunk.position.x / (transform.childCount - 1);
    }

    private void OnEnable()
    {
        for (int i = 0; i < _childChunks.Length; i++)
        {
            _childChunks[i].BecameInvisible += OnChunkBecameInvisible;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _childChunks.Length; i++)
        {
            _childChunks[i].BecameInvisible -= OnChunkBecameInvisible;
        }
    }
}
