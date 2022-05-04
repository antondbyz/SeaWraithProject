using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerHealth : MonoBehaviour
{
    public static event System.Action Died;
    public int Health
    {
        get => _health;
        private set
        {
            value = Mathf.Clamp(value, 0, _maxHealth);
            if(value < _health) 
            {
                AudioPlayer.Instance.PlayRandomAudioOneShot(_explosionAudios);
            }
            _health = value;
            if(_health < _maxHealth)
            {
                _smokeParticles.Play();
                float t = Mathf.Abs(Mathf.InverseLerp(1, _maxHealth - 1, _health) - 1);
                _smokeEmission.rateOverTime = Mathf.Lerp(_smokeEmissionRange.Min, _smokeEmissionRange.Max, t);
            }
            if(_health == 0)
            {
                _gameUI.SetActive(false);
                _smokeEmission.rateOverTime = _smokeEmissionRange.Max;
                Instantiate(_explosionEffect, transform.position, Quaternion.identity);
                if(_collider != null) Destroy(_collider);
                _bubblesParticles.Stop();
                _deathBubblesParticles.Play();
                Died?.Invoke();
            }
        }
    }
    public bool IsAlive => _health > 0;
    [Header("Explosion")]
    [SerializeField] private GameObject _explosionEffect;
    [SerializeField] private AudioClip[] _explosionAudios;
    [SerializeField] private GameObject _gameUI;
    [Header("Bubbles")]
    [SerializeField] private ParticleSystem _bubblesParticles;
    [SerializeField] private ParticleSystem _deathBubblesParticles;
    [Header("Smoke")]
    [SerializeField] private ParticleSystem _smokeParticles;
    [SerializeField] private MinMaxRange<float> _smokeEmissionRange;
    private int _maxHealth;
    private int _health;
    private Collider2D _collider;
    private EmissionModule _smokeEmission;

    public void TakeDamage() => Health--;

    public void Die() => Health = 0;

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
        _smokeEmission = _smokeParticles.emission;
        _maxHealth = SubmarinesManager.CurrentSubmarine.Armor;
        Health = _maxHealth;
    }
}