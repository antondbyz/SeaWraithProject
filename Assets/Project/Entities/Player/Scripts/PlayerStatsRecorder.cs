using UnityEngine;

public class PlayerStatsRecorder : MonoBehaviour
{
    private PlayerCrystals _crystals;
    private PlayerScore _score;

    private void Awake()
    {
        _crystals = GetComponent<PlayerCrystals>();
        _score = GetComponent<PlayerScore>();
    }

    public void RecordStats()
    {
        StatsManager.Instance.UpdateStats(_crystals.CrystalsCollected, _score.Score);
    }
}
