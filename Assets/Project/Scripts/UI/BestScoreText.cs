using TMPro;
using UnityEngine;

public class BestScoreText : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<TMP_Text>().text = $"Best score: {PlayerManager.BestScore}";
    }
}
