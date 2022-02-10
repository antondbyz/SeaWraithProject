using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnable;
    [SerializeField] private Vector2 _spawnAreaSize;
    [SerializeField] private float _spawnRate;

    private float _nextSpawn;
    private PlayerScore _playerScore;
    private HardnessController _hardness;

    private void Awake()
    {
        _playerScore = ObjectsFinder.FindPlayer().GetComponent<PlayerScore>();
        _hardness = ObjectsFinder.FindGameController().GetComponent<HardnessController>();
        _nextSpawn = _spawnRate;
    }

    private void Update()
    {
        if(_playerScore.Score >= _nextSpawn) 
        {
            GameObject spawnedObject = Instantiate(_spawnable, transform.position, transform.rotation);
            float randX = Random.Range(transform.position.x - _spawnAreaSize.x / 2, transform.position.x + _spawnAreaSize.x / 2);
            float randY = Random.Range(transform.position.y - _spawnAreaSize.y / 2, transform.position.y + _spawnAreaSize.y / 2);
            spawnedObject.transform.position = new Vector2(randX, randY);
            _nextSpawn = _playerScore.Score + _spawnRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, _spawnAreaSize);
    }
}
