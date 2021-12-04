using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnable = null;
    [SerializeField] private int _startSpawnScore = 0;
    [Header("Spawn rate")]
    [SerializeField] private int _startSpawnScoreRate = 30;
    [SerializeField] private int _targetSpawnScoreRate = 5;
    [Space(20)]
    [SerializeField] private Vector2 _spawnAreaSize = new Vector2(1, 1);

    private float _nextSpawn;
    private float _spawnRate;

    private void Awake()
    {
        _spawnRate = _startSpawnScoreRate;
    }

    private void Update()
    {
        GameManager gameManager = GameManager.Instance;
        if(gameManager.Score >= _startSpawnScore && gameManager.Score >= _nextSpawn) 
        {
            _spawnRate = Mathf.Lerp(_spawnRate, _targetSpawnScoreRate, gameManager.GameHardnessInterpPoint);
            _nextSpawn = gameManager.Score + _spawnRate;
            GameObject spawnedObject = Instantiate(_spawnable, transform.position, Quaternion.identity);
            float randX = Random.Range(transform.position.x - _spawnAreaSize.x / 2, transform.position.x + _spawnAreaSize.x / 2);
            float randY = Random.Range(transform.position.y - _spawnAreaSize.y / 2, transform.position.y + _spawnAreaSize.y / 2);
            spawnedObject.transform.position = new Vector2(randX, randY);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 0.3f);
        Gizmos.DrawCube(transform.position, _spawnAreaSize);
    }
}
