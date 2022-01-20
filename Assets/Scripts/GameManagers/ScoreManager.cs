using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int Score => _score;

    [SerializeField] private TMP_Text _scoreText;

    private int _score;
    private Transform _player;
    private float _startPlayerXPos;

    private void Start()
    {
        if(Instance == null) Instance = this;
        else Debug.LogWarning("More than one instance of ScoreManager");

        _player = GameObject.FindWithTag("Player").transform;
        _startPlayerXPos = _player.position.x;
    }

    private void Update()
    {
        _score = (int)(_player.position.x - _startPlayerXPos);
        _scoreText.text = _score.ToString();
    }
}
