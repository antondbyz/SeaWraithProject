using UnityEngine;

[RequireComponent(typeof(PlayerCrystals), typeof(PlayerScore))]
public class PlayerProfileRecorder : MonoBehaviour
{
    private PlayerCrystals _crystals;
    private PlayerScore _score;

    private void Awake()
    {
        _crystals = GetComponent<PlayerCrystals>();
        _score = GetComponent<PlayerScore>();
    }

    private void OnEnable()
    {
        GameController.GameFinished += RecordStats;
    }

    private void OnDisable()
    {
        GameController.GameFinished -= RecordStats;
    }

    private void RecordStats()
    {
        PlayerProfile.CrystalsAmount += _crystals.CrystalsCollected;
        if (_score.IsBestScore)
        {
            PlayerProfile.BestScore = _score.Score;
        }
    }
}
