using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health
    {
        get => _health;
        private set
        {
            value = Mathf.Clamp(value, 0, _maxHealth);
            _health = value;
            for(int i = 0; i < _healthSlots.Count; i++)
            {
                _healthSlots[i].Filled = i < _health;
            }
            if(_health == 0)
            {
                Time.timeScale = 0;
            }
        }
    }

    [SerializeField] private int _maxHealth = 3;
    [SerializeField] private HealthSlot _healthSlot = null;
    [SerializeField] private Transform _healthSlotsContainer = null;

    private int _health;
    private List<HealthSlot> _healthSlots = new List<HealthSlot>();

    private void Awake()
    {
        for(int i = 0; i < _maxHealth; i++)
        {
            HealthSlot newHealthSlot = Instantiate(_healthSlot, _healthSlotsContainer);
            _healthSlots.Add(newHealthSlot);
        }
        Health = _maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Bomb"))
        {
            Health--;
        }
    }
}