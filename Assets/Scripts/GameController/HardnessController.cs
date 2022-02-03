using UnityEngine;

public class HardnessController : MonoBehaviour
{
    public float GameHardness => _gameHardness;

    [SerializeField] private float _hardnessingSpeed;

    private float _gameHardness;

    private void Update()
    {
        _gameHardness = Mathf.MoveTowards(_gameHardness, 1, _hardnessingSpeed * Time.deltaTime);
    }
}
