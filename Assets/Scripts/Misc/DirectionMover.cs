using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectionMover : MonoBehaviour
{
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private float _speed;

    private void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(_moveDirection) * _speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(transform.position, _moveDirection));
    }
}