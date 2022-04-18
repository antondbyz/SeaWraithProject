using UnityEngine;

public class Chunk : MonoBehaviour
{
    private ChunksController _controller;

    private void Awake()
    {
        _controller = transform.parent.GetComponent<ChunksController>();
    }

    private void OnBecameInvisible()
    {
        _controller.OnChunkBecameInvisible(transform);
    }
}
