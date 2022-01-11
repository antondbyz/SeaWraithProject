using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RightMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
    }
}