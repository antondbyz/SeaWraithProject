using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float WaterLevel => _waterLevel;

    [SerializeField] private float _waterLevel;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Debug.LogWarning("More than one instance of GameManager");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(0, _waterLevel), new Vector2(10, _waterLevel));
    }
}
