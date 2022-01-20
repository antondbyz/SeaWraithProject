using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectionMover : MonoBehaviour
{
    [SerializeField] private Vector2 _moveDirection;
    [Header("Speed range")]
    [SerializeField] private float _startSpeed;
    [SerializeField] private float _targetSpeed;
    
    private float _speed;

    private void Start()
    {
        _speed = Mathf.Lerp(_startSpeed, _targetSpeed, GameManager.Instance.GameHardness);
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(_moveDirection) * _speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(transform.position, _moveDirection));
    }
}