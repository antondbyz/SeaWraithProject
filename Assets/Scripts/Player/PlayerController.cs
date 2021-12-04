using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 15; 
    [SerializeField] private float _rotateSpeed = 30;
    [SerializeField] private int _maxRotationAngle = 20;
    [SerializeField] private float _alignToBorderSpeed = 50;

    private Rigidbody2D _rigidbody;
    private float _speed;
    private float _maxSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _speed = _minSpeed;
        _maxSpeed = _minSpeed * GameManager.Instance.MaxGameHardness;
    }

    private void FixedUpdate() 
    { 
        bool isOnUpperWorldBound = _rigidbody.position.y >= GameManager.Instance.UpperWorldBound;
        bool isOnLowerWorldBound = _rigidbody.position.y <= GameManager.Instance.LowerWorldBound;

        if(Input.GetKey(KeyCode.DownArrow) && !isOnLowerWorldBound)
        {
            RotateTowards(-_maxRotationAngle, _rotateSpeed);
        }
        else if (isOnUpperWorldBound)
        {
            RotateTowards(0, _alignToBorderSpeed);
        }

        if(Input.GetKey(KeyCode.UpArrow) && !isOnUpperWorldBound)
        {
            RotateTowards(_maxRotationAngle, _rotateSpeed);
        }
        else if (isOnLowerWorldBound)
        {
            RotateTowards(0, _alignToBorderSpeed);
        }
        float clampedYPos = Mathf.Clamp(_rigidbody.position.y, GameManager.Instance.LowerWorldBound, GameManager.Instance.UpperWorldBound);
        _rigidbody.position = new Vector2(_rigidbody.position.x, clampedYPos);
        _speed = Mathf.Lerp(_minSpeed, _maxSpeed, GameManager.Instance.GameHardnessInterpPoint);
        _rigidbody.velocity = transform.right * _speed;
    }

    private void RotateTowards(float targetRotation, float speed)
    {
        _rigidbody.rotation = Mathf.MoveTowards(_rigidbody.rotation, targetRotation, speed * Time.fixedDeltaTime);
    }
}
