using UnityEngine;

public class Chunk : MonoBehaviour
{
    public event System.Action<Transform> BecameInvisible;

    private void OnBecameInvisible()
    {
        BecameInvisible?.Invoke(transform);
    }
}
