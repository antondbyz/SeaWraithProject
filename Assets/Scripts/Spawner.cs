using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnable;
    [SerializeField] private float _spawnRate;
    [Range(0, 1)][SerializeField] private float _spawnProbability;
    [SerializeField] private Vector2 _spawnAreaSize;

    private float _nextSpawn;

    private void Awake()
    {
        _nextSpawn = _spawnRate;
    }

    private void Update()
    {
        GameManager gameManager = GameManager.Instance;
        if(Time.time >= _nextSpawn) 
        {
            if(Random.value <= _spawnProbability)
            {   
                GameObject spawnedObject = Instantiate(_spawnable, transform.position, transform.rotation);
                float randX = Random.Range(transform.position.x - _spawnAreaSize.x / 2, transform.position.x + _spawnAreaSize.x / 2);
                float randY = Random.Range(transform.position.y - _spawnAreaSize.y / 2, transform.position.y + _spawnAreaSize.y / 2);
                spawnedObject.transform.position = new Vector2(randX, randY);
            }
            _nextSpawn = Time.time + _spawnRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, _spawnAreaSize);
    }
}
