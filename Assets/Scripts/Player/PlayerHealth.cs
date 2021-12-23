using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health
    {
        get => _health;
        set
        {
            value = Mathf.Clamp(value, 0, _maxHealth);
            _health = value;
            if(_health == 0)
            {
                Time.timeScale = 0;
            }
        }
    }

    [SerializeField] private int _maxHealth = 3;

    private int _health;

    private void Awake()
    {
        Health = _maxHealth;
    }
}