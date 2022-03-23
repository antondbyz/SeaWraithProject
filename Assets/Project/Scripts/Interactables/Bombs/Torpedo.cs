using UnityEngine;

[RequireComponent(typeof(MovementController), typeof(BoxCollider2D), typeof(SpriteRenderer))]
public class Torpedo : Bomb
{
    private MovementController _movement;
    private BoxCollider2D _collider;
    private SpriteRenderer _renderer;
    private ParticleSystem[] _particles;
    
    public override void Disappear()
    {
        for (int i = 0; i < _particles.Length; i++)
        {
            _particles[i].Stop();
        }
        _collider.enabled = false;
        _renderer.enabled = false;
    }

    protected override void Initialize()
    {
        for (int i = 0; i < _particles.Length; i++)
        {
            _particles[i].Play();
        }
        _movement.UpdateMovement();
        _collider.enabled = true;
        _renderer.enabled = true;
    }

    private void Awake()
    {
        _movement = GetComponent<MovementController>();
        _collider = GetComponent<BoxCollider2D>();
        _renderer = GetComponent<SpriteRenderer>();
        _particles = GetComponentsInChildren<ParticleSystem>();
    }
}