using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score => _score;
    public bool IsBestScore => _isBestScore;

    [SerializeField] private TMP_Text _scoreText;
    [Header("Text gradients")]
    [SerializeField] private TMP_ColorGradient _defaultScoreGradient;
    [SerializeField] private TMP_ColorGradient _bestScoreGradient;

    private int _score;
    private bool _isBestScore;
    private float _startXPos;

    private void Awake()
    {
        _startXPos = transform.position.x;
        _scoreText.colorGradientPreset = _defaultScoreGradient;
    }

    private void Update()
    {
        _score = (int)(transform.position.x - _startXPos);
        if(!_isBestScore && _score > StatsManager.BestScore)
        {
            _scoreText.colorGradientPreset = _bestScoreGradient;
            _isBestScore = true;
        }
        _scoreText.text = Score.ToString();
    }
}
