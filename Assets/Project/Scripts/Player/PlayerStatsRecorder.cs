using UnityEngine;

public class PlayerStatsRecorder : MonoBehaviour
{
    private PlayerCrystals _crystals;
    private PlayerScore _score;
    private PlayerHealth _health;

    private void Awake()
    {
        _crystals = GetComponent<PlayerCrystals>();
        _score = GetComponent<PlayerScore>();
        _health = GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _health.Died += RecordStats;
    }

    private void OnDisable()
    {
        _health.Died -= RecordStats;
    }

    private void RecordStats()
    {
        PlayerStatsManager.CrystalsAmount += _crystals.CrystalsCollected;
        if (_score.IsBestScore)
        {
            PlayerStatsManager.BestScore = _score.Score;
        }
    }
}
