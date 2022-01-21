using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private MinMaxRange _speedRange;
    [Header("Game border")]
    [SerializeField] private float _upperBorder;
    [SerializeField] private float _alignToBorderSpeed;
    [Header("Rotation")]
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private int _maxRotationAngle;

    private Rigidbody2D _rigidbody;
    private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    { 
        bool isOnUpperBorder = transform.position.y >= _upperBorder;
        if(Input.GetKey(KeyCode.UpArrow) && !isOnUpperBorder)
        {
            RotateTowards(_maxRotationAngle, _rotateSpeed);
        }
        if(Input.GetKey(KeyCode.DownArrow) && (!isOnUpperBorder || _rigidbody.rotation <= 0))
        {
            RotateTowards(-_maxRotationAngle, _rotateSpeed);
        }
        if (isOnUpperBorder && _rigidbody.rotation > 0)
        {
            RotateTowards(0, _alignToBorderSpeed);
        }

        float clampedYPos = Mathf.Clamp(_rigidbody.position.y, Mathf.NegativeInfinity, _upperBorder);
        _rigidbody.position = new Vector2(_rigidbody.position.x, clampedYPos);

        _speed = Mathf.Lerp(_speedRange.Min, _speedRange.Max, HardnessManager.Instance.GameHardness);
        _rigidbody.velocity = transform.right * _speed;
    }

    private void RotateTowards(float targetRotation, float speed)
    {
        _rigidbody.rotation = Mathf.MoveTowards(_rigidbody.rotation, targetRotation, speed * Time.fixedDeltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(0, _upperBorder), new Vector2(10, _upperBorder));
    }
}
