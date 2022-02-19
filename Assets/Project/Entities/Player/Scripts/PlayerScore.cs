using TMPro;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int Score { get; private set; }

    [SerializeField] private TMP_Text _scoreText;

    private float _startXPos;

    private void Awake()
    {
        _startXPos = transform.position.x;
    }

    private void Update()
    {
        Score = (int)(transform.position.x - _startXPos);
        _scoreText.text = Score.ToString();
    }
}
