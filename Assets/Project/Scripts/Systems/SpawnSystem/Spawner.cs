using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected GameObject _object;
    [SerializeField] private int _poolLength;
    [SerializeField] private Vector2 _spawnAreaSize; 
    [SerializeField] private float _spawnRate;
    private PlayerScore _playerScore;
    private Queue<ISpawnable> _pool = new Queue<ISpawnable>();
    private float _nextSpawn;

    private void Awake()
    {
        _playerScore = ObjectsFinder.FindPlayer().GetComponent<PlayerScore>();
        _nextSpawn = _spawnRate;
        if (_object.GetComponent<ISpawnable>() == null)
        {
            Debug.LogError($"{_object.name} can't be spawned!");
            return;
        }
        for (int i = 0; i < _poolLength; i++)
        {
            GameObject instance = Instantiate(_object);
            ISpawnable spawnable = instance.GetComponent<ISpawnable>();
            spawnable.Disappear();
            _pool.Enqueue(spawnable);
        }
    }

    private void Update()
    {
        if(_playerScore.Score >= _nextSpawn) 
        {
            float xPos = Random.Range(transform.position.x - _spawnAreaSize.x / 2, transform.position.x + _spawnAreaSize.x / 2);
            float yPos = Random.Range(transform.position.y - _spawnAreaSize.y / 2, transform.position.y + _spawnAreaSize.y / 2);
            ISpawnable spawnable = _pool.Dequeue();
            spawnable.Spawn(new Vector2(xPos, yPos));
            _pool.Enqueue(spawnable);
            _nextSpawn = _playerScore.Score + _spawnRate;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, _spawnAreaSize);
    }
}
