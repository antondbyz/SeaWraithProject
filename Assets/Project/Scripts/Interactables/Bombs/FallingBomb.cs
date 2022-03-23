 using UnityEngine;

[RequireComponent(typeof(SpriteRenderer), typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class FallingBomb : Bomb
{
    [SerializeField] private MinMaxRange<float> _gravityRange;
    [SerializeField] private MinMaxRange<float> _torqueRange;

    private SpriteRenderer _renderer;
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _collider;
    private ParticleSystem[] _particles;

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
        _rigidbody.gravityScale = Random.Range(_gravityRange.Min, _gravityRange.Max);
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
    }

    private void ResetMovement()
    {
        _rigidbody.gravityScale = 0;
        _rigidbody.velocity = Vector2.zero;
        _rigidbody.angularVelocity = 0;
    }
}