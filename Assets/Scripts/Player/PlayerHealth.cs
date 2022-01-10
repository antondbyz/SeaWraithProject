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
                Die();
            }
        }
    }

    [SerializeField] private int _maxHealth;

    private int _health;

    private void Awake()
    {
        Health = _maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Health = 0;
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
    }
}