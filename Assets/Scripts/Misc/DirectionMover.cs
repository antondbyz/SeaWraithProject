using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class DirectionMover : MonoBehaviour
{
    [SerializeField] private Vector2 _moveDirection;
    [SerializeField] private MinMaxRange<float> _speedRange;
    
    private float _speed;

    private void Awake()
    {
        _speed = Mathf.Lerp(_speedRange.Min, _speedRange.Max, HardnessManager.Instance.GameHardness);
        GetComponent<Rigidbody2D>().velocity = transform.TransformDirection(_moveDirection) * _speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(transform.position, _moveDirection));
    }
}