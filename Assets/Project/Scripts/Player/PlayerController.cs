using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerHealth))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private MinMaxRange<float> _speedRange;
    [Header("Game border")]
    [SerializeField] private Camera _camera;
    [SerializeField] private float _borderHeightOffset;
    [SerializeField] private float _alignToBorderSpeed;
    [Header("Rotation")]
    [SerializeField] private int _maxRotationAngle;
    [Header("Sink")]
    [SerializeField] private float _sinkGravity;
    [SerializeField] private float _sinkRotateSpeed;
    [SerializeField] private float _sinkSlowingSpeed;

    private Rigidbody2D _rigidbody;
    private PlayerHealth _health;
    private GameSpeed _gameSpeed;
    private InputController _input;
    private float _speed;
    private Vector2 _newVelocity;
    private float _rotateSpeed;
    private float _sinkGravityCached;
    private float _borderHeight;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _health = GetComponent<PlayerHealth>();
        _gameSpeed = GetComponent<GameSpeed>();
        _input = GetComponent<InputController>();
        _rotateSpeed = StatsManager.SubmarineStats.Mobility;
        _sinkGravityCached = _sinkGravity;
        _borderHeight = GetBorderHeight(_camera);
    }

    private void FixedUpdate() 
    { 
        if(_health.IsAlive)
        {
            bool isOnUpperBorder = transform.position.y >= _borderHeight;
            float verticalInput = _input.VerticalInput;
            if(verticalInput > 0 && !isOnUpperBorder)
            {
                _rigidbody.rotation = MoveTowardsFixed(_rigidbody.rotation, _maxRotationAngle, _rotateSpeed);
            }
            if(verticalInput < 0 && (!isOnUpperBorder || _rigidbody.rotation <= 0))
            {
                _rigidbody.rotation = MoveTowardsFixed(_rigidbody.rotation, -_maxRotationAngle, _rotateSpeed);
            }
            if (isOnUpperBorder && _rigidbody.rotation > 0)
            {
                _rigidbody.rotation = MoveTowardsFixed(_rigidbody.rotation, 0, _alignToBorderSpeed);
            }

            float clampedYPos = Mathf.Clamp(_rigidbody.position.y, Mathf.NegativeInfinity, _borderHeight);
            _rigidbody.position = new Vector2(_rigidbody.position.x, clampedYPos);

            _speed = Mathf.Lerp(_speedRange.Min, _speedRange.Max, _gameSpeed.Speed);
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

    private float GetBorderHeight(Camera camera) 
    {
        if (camera == null) return 0;
        Vector2 borderScreenPoint = new Vector2(0, camera.scaledPixelHeight);
        return camera.ScreenToWorldPoint(borderScreenPoint).y + _borderHeightOffset;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(new Vector3(transform.position.x, GetBorderHeight(Camera.main)), Vector3.right));
    }
}
