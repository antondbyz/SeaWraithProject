using System.Collections;
using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [Header("Death menu")]
    [SerializeField] private GameObject _deathMenu;
    [SerializeField] private GameObject _doubleCrystalsMenu;
    [SerializeField] private GameObject _mainDeathMenu;
    [SerializeField] private float _showMenuDelay;
    [Header("Score text")]
    [SerializeField] private TMP_Text _finalScoreText;
    [SerializeField] private TMP_ColorGradient _defaultScoreGradient;
    [SerializeField] private TMP_ColorGradient _bestScoreGradient;
    [Space]
    [SerializeField] private TMP_Text _finalCrystalsText;
    private PlayerScore _playerScore;
    private PlayerCrystals _playerCrystals;

    private void Awake()
    {
        GameObject player = ObjectsFinder.FindPlayer();
        _playerScore = player.GetComponent<PlayerScore>();
        _playerCrystals = player.GetComponent<PlayerCrystals>();
    }

    private void OnEnable()
    {
        PlayerHealth.Died += OnPlayerDied;
        _playerCrystals.CrystalsChanged += UpdateCrystalsUI;
    }

    private void OnDisable()
    {
        PlayerHealth.Died -= OnPlayerDied;
        _playerCrystals.CrystalsChanged -= UpdateCrystalsUI;
    }

    private void OnPlayerDied()
    {
        _doubleCrystalsMenu.SetActive(_playerCrystals.CrystalsCollected > 0);
        _mainDeathMenu.SetActive(_playerCrystals.CrystalsCollected <= 0);
        _finalScoreText.text = _playerScore.Score.ToString();
        _finalScoreText.colorGradientPreset = _playerScore.IsBestScore ? _bestScoreGradient : _defaultScoreGradient;
        UpdateCrystalsUI();
        StartCoroutine(ShowMenu());
    }

    private void UpdateCrystalsUI() => _finalCrystalsText.text = $"+{_playerCrystals.CrystalsCollected}";

    private IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(_showMenuDelay);
        _deathMenu.SetActive(true);
    }
}
