using UnityEngine;
using UnityEngine.UI;

public class TorpedoesShooter : MonoBehaviour
{
    [SerializeField] private GameObject _playerTorpedo = null;
    [SerializeField] private float _reloadTime = 3;
    [SerializeField] private Image _reloadIndicator = null;

    private float _nextShootTime;
    private float _lastShootTime;

    private void Awake()
    {
        _nextShootTime = _reloadTime;
    }

    private void Update()
    {
        if(Time.time <= _nextShootTime)
        {
            _reloadIndicator.fillAmount = (Time.time - _lastShootTime) / (_nextShootTime - _lastShootTime);
            _reloadIndicator.gameObject.SetActive(true);
        }
        else 
        {
            _reloadIndicator.gameObject.SetActive(false);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(_playerTorpedo, transform.position, transform.rotation);
                _nextShootTime = Time.time + _reloadTime;
                _lastShootTime = Time.time;
            }
        }
    }
}