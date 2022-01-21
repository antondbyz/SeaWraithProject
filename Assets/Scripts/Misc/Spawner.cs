using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnable;
    [SerializeField] private MinMaxRange _spawnRateRange;
    [SerializeField] private Vector2 _spawnAreaSize;

    private float _spawnRate;
    private float _nextSpawn;

    private void Start()
    {
        _nextSpawn = _spawnRateRange.Min;
    }

    private void Update()
    {
        _spawnRate = Mathf.Lerp(_spawnRateRange.Min, _spawnRateRange.Max, HardnessManager.Instance.GameHardness);
        if(ScoreManager.Instance.Score >= _nextSpawn) 
        {
            GameObject spawnedObject = Instantiate(_spawnable, transform.position, transform.rotation);
            float randX = Random.Range(transform.position.x - _spawnAreaSize.x / 2, transform.position.x + _spawnAreaSize.x / 2);
            float randY = Random.Range(transform.position.y - _spawnAreaSize.y / 2, transform.position.y + _spawnAreaSize.y / 2);
            spawnedObject.transform.position = new Vector2(randX, randY);
            _nextSpawn = ScoreManager.Instance.Score + _spawnRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, _spawnAreaSize);
    }
}
