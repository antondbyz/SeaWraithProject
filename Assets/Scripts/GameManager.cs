using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float UpperWorldBound => _upperWorldBound;
    public float LowerWorldBound => _lowerWorldBound;
    public int Score => _score;
    public float GameSpeed => _gameSpeed;
    public float GameSpeedInterpolationPoint => (_gameSpeed - _minGameSpeed) / (_maxGameSpeed - _minGameSpeed);

    [SerializeField] private float _upperWorldBound = 0;
    [SerializeField] private float _lowerWorldBound = 0;
    [Header("Game speed")]
    [SerializeField] private float _minGameSpeed = 15;
    [SerializeField] private float _maxGameSpeed = 40;
    [SerializeField] private float _gameAcceleration = 0.5f;
    [Space(20)]
    [SerializeField] private TMP_Text _scoreText = null;

    private Transform _player = null;
    private float _gameSpeed;

    private int _score;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this);

        _player = GameObject.FindWithTag("Player").transform;
        _gameSpeed = _minGameSpeed;
    }

    private void Update()
    {
        _gameSpeed = Mathf.MoveTowards(_gameSpeed, _maxGameSpeed, _gameAcceleration * Time.deltaTime);
        _score = (int)_player.position.x;
        _scoreText.text = _score.ToString();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(new Vector2(transform.position.x, _upperWorldBound), Vector2.right * 10);
        Gizmos.DrawRay(new Vector2(transform.position.x, _lowerWorldBound), Vector2.right * 10);
    }
}
