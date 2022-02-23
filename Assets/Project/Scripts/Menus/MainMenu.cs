using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private TMP_Text _maxScoreText;

    private void Awake()
    {
        _maxScoreText.text = $"Best score: {StatsManager.MaxScore}";
    }
}
