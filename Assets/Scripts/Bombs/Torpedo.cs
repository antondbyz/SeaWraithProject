using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : MonoBehaviour
{
    [SerializeField] private float _startSpeed = 35;

    private Rigidbody2D _rigidbody;
    private float _speed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        float maxSpeed = _startSpeed * GameManager.Instance.MaxGameHardness;
        _speed = Mathf.Lerp(_startSpeed, maxSpeed, GameManager.Instance.GameHardnessInterpPoint);
        _rigidbody.velocity = transform.right * _speed;
        GetComponentInChildren<AliveOnlyOnScreen>().BecameInvisible += DestroySelf;
    }

    private void DestroySelf() => Destroy(gameObject);
}