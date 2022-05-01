using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    [SerializeField] protected MinMaxRange<float> _speedRange;
    [SerializeField] protected Vector2 _direction;
    protected Rigidbody2D _rigidbody;
    protected GameSpeedController _gameSpeed; 
    protected float _speed;

    public void UpdateMovement()
    {
        _speed = Mathf.Lerp(_speedRange.Min, _speedRange.Max, _gameSpeed.Speed);
        UpdateVelocity();
    }

    public void UpdateVelocity()
    {
        _rigidbody.velocity = transform.TransformDirection(_direction) * _speed;
    }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameSpeed = ObjectsFinder.FindGameController().GetComponent<GameSpeedController>();
        UpdateMovement();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(transform.position, _direction));
    }
}
