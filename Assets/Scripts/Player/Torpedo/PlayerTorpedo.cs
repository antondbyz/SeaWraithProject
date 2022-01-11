using UnityEngine;

public class PlayerTorpedo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Bomb bomb = other.GetComponent<Bomb>();
        if(bomb != null)
        {
            bomb.Explode();
            Destroy(gameObject);
        }
    }
}
