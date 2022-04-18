 using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class FallingBomb : Bomb
{
    [SerializeField] private MinMaxRange<float> _torqueRange;
    [SerializeField] [Range(1, 10)] private float _waterFriction;
    [SerializeField] private GameObject _waterSplashEffect;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    private ParticleSystem[] _particles;
    private float _startGravity;

    public override void Disappear()
    {
        for (int i = 0; i < _particles.Length; i++)
        {
            _particles[i].Stop();
        }
        _renderer.enabled = false;
        _collider.enabled = false;
    }
    
    protected override void Initialize()
    {
        ResetMovement();
        _rigidbody.gravityScale = _startGravity;
        float torque = Random.Range(_torqueRange.Min, _torqueRange.Max);
        torque = Random.Range(0f, 1f) > 0.5f ? -torque : torque;
        _rigidbody.AddTorque(torque);
        for (int i = 0; i < _particles.Length; i++)
        {
            _particles[i].Play();
        }
        _renderer.enabled = true;
        _collider.enabled = true;
    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _collider = GetComponent<BoxCollider2D>();
        _particles = GetComponentsInChildren<ParticleSystem>();
        _startGravity = _rigidbody.gravityScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Water"))
        {
            Instantiate(_waterSplashEffect, transform.position, Quaternion.identity);
            _rigidbody.gravityScale = 0; 
            _rigidbody.velocity /= _waterFriction;
        }
    }

    private void ResetMovement()
    {
        _rigidbody.gravityScale = 0;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
    }
}