using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    public float Speed { get; private set; }

    [SerializeField] private float _accelerationRate;

    private PlayerHealth _health;

    private void Awake()
    {
        _health = ObjectsFinder.FindPlayer().GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _health.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnPlayerDied;
    }

    private void Update()
    {
        if (_health.IsAlive) 
        {
            Speed = Mathf.MoveTowards(Speed, 1, _accelerationRate * Time.deltaTime);
        }
    }

    private void OnPlayerDied()
    {
        Speed = 0;
    }
}
