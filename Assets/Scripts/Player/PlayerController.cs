using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private int _maxRotationAngle;
    [SerializeField] private float _alignToBorderSpeed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    { 
        bool isOnWaterLevel = transform.position.y >= GameManager.Instance.WaterLevel;
        if(Input.GetKey(KeyCode.DownArrow))
        {
            RotateTowards(-_maxRotationAngle, _rotateSpeed);
        }
        else if (isOnWaterLevel)
        {
            RotateTowards(0, _alignToBorderSpeed);
        }

        if(Input.GetKey(KeyCode.UpArrow) && !isOnWaterLevel)
        {
            RotateTowards(_maxRotationAngle, _rotateSpeed);
        }
        float clampedYPos = Mathf.Clamp(_rigidbody.position.y, Mathf.NegativeInfinity, GameManager.Instance.WaterLevel);
        _rigidbody.position = new Vector2(_rigidbody.position.x, clampedYPos);
        _rigidbody.velocity = transform.right * _speed;
    }

    private void RotateTowards(float targetRotation, float speed)
    {
        _rigidbody.rotation = Mathf.MoveTowards(_rigidbody.rotation, targetRotation, speed * Time.fixedDeltaTime);
    }
}
