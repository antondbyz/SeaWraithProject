using System.Collections;
using TMPro;
using UnityEngine;

public class DeathMenu : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject _menu;
    [SerializeField] private float _showMenuDelay;
    [Space]
    [SerializeField] private TMP_Text _finalScoreText;

    private PlayerHealth _playerHealth;
    private PlayerScore _playerScore;

    private void Awake()
    {
        GameObject player = ObjectsFinder.FindPlayer();
        _playerHealth = player.GetComponent<PlayerHealth>();
        _playerScore = player.GetComponent<PlayerScore>();
    }

    private void OnEnable()
    {
        _playerHealth.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _playerHealth.Died -= OnPlayerDied;
    }

    private void OnPlayerDied()
    {
        _finalScoreText.text = "Score: " + _playerScore.Score;
        StartCoroutine(ShowMenu());
    }

    private IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(_showMenuDelay);
        _menu.SetActive(true);
    }
}
