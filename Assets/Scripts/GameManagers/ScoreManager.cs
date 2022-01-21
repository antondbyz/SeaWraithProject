using TMPro;
using UnityEngine;

public class ScoreManager : Singleton<ScoreManager>
{
    public int Score => _score;

    [SerializeField] private TMP_Text _scoreText;

    private int _score;
    private Transform _player;
    private float _startPlayerXPos;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player").transform;
        _startPlayerXPos = _player.position.x;
    }

    private void Update()
    {
        _score = (int)(_player.position.x - _startPlayerXPos);
        _scoreText.text = _score.ToString();
    }
}
