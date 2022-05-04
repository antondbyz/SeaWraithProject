using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    public float Speed { get; private set; }
    [SerializeField] private float _accelerationRate;
    private bool _isPlayerAlive = true;

    private void OnEnable()
    {
        PlayerHealth.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        PlayerHealth.Died -= OnPlayerDied;
    }

    private void Update()
    {
        if (_isPlayerAlive) 
        {
            Speed = Mathf.MoveTowards(Speed, 1, _accelerationRate * Time.deltaTime);
        }
    }

    private void OnPlayerDied()
    {
        Speed = 0;
        _isPlayerAlive = false;
    }
}
