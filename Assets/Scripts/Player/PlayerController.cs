using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerHealth))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private MinMaxRange<float> _speedRange;
    [Header("Game border")]
    [SerializeField] private float _upperBorder;
    [SerializeField] private float _alignToBorderSpeed;
    [Header("Rotation")]
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private int _maxRotationAngle;
    [Header("Sink")]
    [SerializeField] private float _sinkGravity;
    [SerializeField] private float _sinkRotateSpeed;
    [SerializeField] private float _sinkSlowingSpeed;


    private Rigidbody2D _rigidbody;
    private PlayerHealth _health;
    private HardnessController _hardness;
    private float _speed;
    private Vector2 _newVelocity;
    private float _sinkGravityCached;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<PlayerHealth>();
        _hardness = ObjectsFinder.FindGameController().GetComponent<HardnessController>();
        _sinkGravityCached = _sinkGravity;
    }

    private void FixedUpdate() 
    { 
        if(_health.IsAlive)
        {
            bool isOnUpperBorder = transform.position.y >= _upperBorder;
            if(Input.GetKey(KeyCode.UpArrow) && !isOnUpperBorder)
            {
                _rigidbody.rotation = MoveTowardsFixed(_rigidbody.rotation, _maxRotationAngle, _rotateSpeed);
            }
            if(Input.GetKey(KeyCode.DownArrow) && (!isOnUpperBorder || _rigidbody.rotation <= 0))
            {
                _rigidbody.rotation = MoveTowardsFixed(_rigidbody.rotation, -_maxRotationAngle, _rotateSpeed);
            }
            if (isOnUpperBorder && _rigidbody.rotation > 0)
            {
                _rigidbody.rotation = MoveTowardsFixed(_rigidbody.rotation, 0, _alignToBorderSpeed);
            }

            float clampedYPos = Mathf.Clamp(_rigidbody.position.y, Mathf.NegativeInfinity, _upperBorder);
            _rigidbody.position = new Vector2(_rigidbody.position.x, clampedYPos);

            _speed = Mathf.Lerp(_speedRange.Min, _speedRange.Max, _hardness.GameHardness);
            _newVelocity = transform.right * _speed;
        }
        else
        {
            _rigidbody.rotation = MoveTowardsFixed(_rigidbody.rotation, -90, _sinkRotateSpeed);
            _speed = MoveTowardsFixed(_speed, 0, _sinkSlowingSpeed);
            _sinkGravity += _sinkGravityCached * Time.fixedDeltaTime;
            _newVelocity = (Vector2)(transform.right * _speed) - (Vector2.up * _sinkGravity);
        }
        _rigidbody.velocity = _newVelocity;
    }

    private float MoveTowardsFixed(float current, float target, float speed)
    {
        return Mathf.MoveTowards(current, target, speed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(0, _upperBorder), new Vector2(10, _upperBorder));
    }
}
