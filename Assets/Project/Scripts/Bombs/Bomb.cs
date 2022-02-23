using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private GameObject _explosionEffect;

    public void Explode()
    {
        Instantiate(_explosionEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
