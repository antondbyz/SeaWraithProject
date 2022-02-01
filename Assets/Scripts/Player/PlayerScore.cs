using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score => _score;

    [SerializeField] private TMP_Text _scoreText;

    private int _score;
    private float _startXPos;
    private PlayerHealth _playerHealth;

    private void Awake()
    {
        _playerHealth = GetComponent<PlayerHealth>();
        _startXPos = transform.position.x;
    }

    private void OnEnable()
    {
        _playerHealth.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= OnPlayerDied;
    }

    private void Update()
    {
        _score = (int)(transform.position.x - _startXPos);
        if(_playerHealth.IsAlive)
        {
            _scoreText.text = _score.ToString();
        }
    }

    private void OnPlayerDied() 
    {
        _scoreText.gameObject.SetActive(false);
    } 
}
