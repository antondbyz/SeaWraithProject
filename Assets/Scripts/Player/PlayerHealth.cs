using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerHealth : MonoBehaviour
{
    public event System.Action Died;
    public bool IsAlive => _health > 0;
    public int Health
    {
        get => _health;
        set
        {
            value = Mathf.Clamp(value, 0, _maxHealth);
            _health = value;
            if(_health < _maxHealth)
            {
                _smokeParticles.Play();
                float t = Mathf.Abs(Mathf.InverseLerp(1, _maxHealth - 1, _health) - 1);
                _emission.rateOverTime = Mathf.Lerp(_smokeEmissionRange.Min, _smokeEmissionRange.Max, t);
            }
            if(_health == 0)
            {
                if(_collider != null) Destroy(_collider);
                _bubblesParticles.Stop();
                _deathBubblesParticles.Play();
                Died?.Invoke();
            }
        }
    }

    [SerializeField] private int _maxHealth;
    [Header("Bubbles particles")]
    [SerializeField] private ParticleSystem _bubblesParticles;
    [SerializeField] private ParticleSystem _deathBubblesParticles;
    [Header("Smoke")]
    [SerializeField] private ParticleSystem _smokeParticles;
    [SerializeField] private MinMaxRange<float> _smokeEmissionRange;

    private int _health;
    private EmissionModule _emission;
    private Collider2D _collider;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _emission = _smokeParticles.emission;
        Health = _maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Health = 0;
        }
    }
}