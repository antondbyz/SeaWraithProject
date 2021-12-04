using UnityEngine;

public class AliveOnlyOnScreen : MonoBehaviour
{
    public event System.Action BecameInvisible;

    private void OnBecameInvisible()
    {
        BecameInvisible?.Invoke();
        Destroy(gameObject);
    }
}
