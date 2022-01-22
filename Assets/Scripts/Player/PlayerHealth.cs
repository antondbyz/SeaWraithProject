using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerHealth : MonoBehaviour
{
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
                gameObject.SetActive(false);
            }
        }
    }

    [SerializeField] private int _maxHealth;
    [Header("Smoke")]
    [SerializeField] private ParticleSystem _smokeParticles;
    [SerializeField] private MinMaxRange<float> _smokeEmissionRange;

    private int _health;
    private EmissionModule _emission;

    private void Start()
    {
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