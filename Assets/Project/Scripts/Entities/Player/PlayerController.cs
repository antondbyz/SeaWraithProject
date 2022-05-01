using UnityEngine;

[RequireComponent(typeof(PlayerHealth))]
public class PlayerController : MovementController
{
    [SerializeField] private int _maxRotationAngle;
    [Header("WaterLevel")]
    [SerializeField] private float _waterLevel;
    [SerializeField] private float _alignToWaterSpeed;
    [Header("Sink")]
    [SerializeField] private float _sinkGravity;
    [SerializeField] private float _sinkRotateSpeed;
    [SerializeField] private float _sinkSlowingSpeed;
    private PlayerHealth _health;
    private InputController _input;
    private int _rotateSpeed;
    private Vector2 _sinkVelocity;

    protected override void Awake()
    {
        base.Awake();
        _health = GetComponent<PlayerHealth>();
        _input = ObjectsFinder.FindGameController().GetComponent<InputController>();
        _rotateSpeed = SubmarinesManager.CurrentSubmarine.Mobility;
    }

    private void FixedUpdate() 
    {
        bool isOnWaterLevel = transform.position.y >= _waterLevel;
        float clampedYPos = Mathf.Clamp(_rigidbody.position.y, Mathf.NegativeInfinity, _waterLevel);
        _rigidbody.position = new Vector2(_rigidbody.position.x, clampedYPos);
        if (isOnWaterLevel && _rigidbody.rotation > 0)
        {
            _rigidbody.rotation = Mathf.MoveTowards(_rigidbody.rotation, 0, _alignToWaterSpeed * Time.fixedDeltaTime);
        }
        if(_health.IsAlive)
        {
            float verticalInput = _input.VerticalInput;
            if(verticalInput > 0 && !isOnWaterLevel)
            {
                _rigidbody.rotation = Mathf.MoveTowards(_rigidbody.rotation, _maxRotationAngle, _rotateSpeed * Time.fixedDeltaTime);
            }
            if(verticalInput < 0 && (!isOnWaterLevel || _rigidbody.rotation <= 0))
            {
                _rigidbody.rotation = Mathf.MoveTowards(_rigidbody.rotation, -_maxRotationAngle, _rotateSpeed * Time.fixedDeltaTime);
            }
            UpdateMovement();
        }
        else
        {
            _rigidbody.rotation = Mathf.MoveTowards(_rigidbody.rotation, -90, _sinkRotateSpeed * Time.fixedDeltaTime);
            _speed = Mathf.MoveTowards(_speed, 0, _sinkSlowingSpeed * Time.fixedDeltaTime);
            _sinkVelocity += -Vector2.up * _sinkGravity * Time.fixedDeltaTime;
            UpdateVelocity();
            _rigidbody.velocity += _sinkVelocity;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Ray(new Vector2(transform.position.x, _waterLevel), Vector2.right));
    }
}
