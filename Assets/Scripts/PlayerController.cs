using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed = 30;
    [SerializeField] private int _maxRotationAngle = 20;
    [SerializeField] private float _alignToBorderSpeed = 50;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
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
        _rigidbody.velocity = transform.right * GameManager.Instance.GameSpeed;
    }

    private void RotateTowards(float targetRotation, float speed)
    {
        _rigidbody.rotation = Mathf.MoveTowards(_rigidbody.rotation, targetRotation, speed * Time.fixedDeltaTime);
    }
}
