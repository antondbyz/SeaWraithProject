using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score => _score;

    [SerializeField] private TMP_Text _scoreText;

    private int _score;
    private float _startXPos;

    private void Awake()
    {
        _startXPos = transform.position.x;
    }

    private void Update()
    {
        _score = (int)(transform.position.x - _startXPos);
        _scoreText.text = _score.ToString();
    }
}
