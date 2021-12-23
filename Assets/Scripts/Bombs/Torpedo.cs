using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Torpedo : Bomb
{
    [SerializeField] private float _startSpeed = 40;
    [SerializeField] private float _targetSpeed = 80;

    private Rigidbody2D _rigidbody;
    private float _speed;

    private void Awake()
    {
        _speed = Mathf.Lerp(_startSpeed, _targetSpeed, GameManager.Instance.GameHardnessInterpPoint);
        GetComponent<Rigidbody2D>().velocity = transform.right * _speed;
    }
}