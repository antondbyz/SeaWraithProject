using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float WaterLevel => _waterLevel;
    public float GameHardness => _gameHardness;

    [SerializeField] private float _waterLevel;
    [SerializeField] private float _gameHardnessingSpeed;

    private float _gameHardness;

    private void Awake()
    {
        if(Instance == null) Instance = this;
        else Debug.LogWarning("More than one instance of GameManager");
    }

    private void Update()
    {
        _gameHardness = Mathf.MoveTowards(_gameHardness, 1, _gameHardnessingSpeed * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(0, _waterLevel), new Vector2(10, _waterLevel));
    }
}
