using UnityEngine;

public class PlayerTorpedo : Torpedo
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bomb"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
