using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float UpperWorldBound => _upperWorldBound;
    public float LowerWorldBound => _lowerWorldBound;
    public int Score => _score;
    public float MaxGameHardness => _maxGameHardness;
    public float GameHardnessInterpPoint => _gameHardness / _maxGameHardness;

    [SerializeField] private float _upperWorldBound = 0;
    [SerializeField] private float _lowerWorldBound = 0;
    [Header("Game hardness")]
    [SerializeField] private float _startGameHardness = 1;
    [SerializeField] private float _maxGameHardness = 3;
    [SerializeField] private float _gameHardnessingSpeed = 0.1f;
    [Space(20)]
    [SerializeField] private TMP_Text _scoreText = null;

    private Transform _player = null;
    private float _gameHardness;
    private int _score;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Destroy(this);

        _player = GameObject.FindWithTag("Player").transform;
        _gameHardness = _startGameHardness;
    }

    private void Update()
    {
        _gameHardness = Mathf.MoveTowards(_gameHardness, _maxGameHardness, _gameHardnessingSpeed * Time.deltaTime);
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
