using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : MonoBehaviour
{
    [SerializeField] private float _speed = 35;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
    }
}