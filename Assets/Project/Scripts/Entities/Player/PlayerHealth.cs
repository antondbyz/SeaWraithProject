using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerHealth : MonoBehaviour
{
    public event System.Action Died;
    public int Health
    {
        get => _health;
        private set
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
                _gameUI.SetActive(false);
                Instantiate(_explosionEffect, transform.position, Quaternion.identity);
                if(_collider != null) Destroy(_collider);
                _bubblesParticles.Stop();
                _deathBubblesParticles.Play();
                Died?.Invoke();
            }
        }
    }
    public bool IsAlive => _health > 0;

    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private GameObject _gameUI;
    [Header("Bubbles particles")]
    [SerializeField] private ParticleSystem _bubblesParticles;
    [SerializeField] private ParticleSystem _deathBubblesParticles;
    [Header("Smoke")]
    [SerializeField] private ParticleSystem _smokeParticles;
    [SerializeField] private MinMaxRange<float> _smokeEmissionRange;

    private int _maxHealth;
    private int _health;
    private Collider2D _collider;
    private EmissionModule _emission;

    public void TakeDamage() => Health--;

    public void Die() => Health = 0;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _emission = _smokeParticles.emission;
        _maxHealth = SubmarinesManager.CurrentSubmarine.Armor;
        Health = _maxHealth;
    }
}