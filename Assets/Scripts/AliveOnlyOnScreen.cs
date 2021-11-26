using UnityEngine;

public class AliveOnlyOnScreen : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
