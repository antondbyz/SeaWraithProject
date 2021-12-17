using UnityEngine;

public class TorpedoesShooter : MonoBehaviour
{
    [SerializeField] private GameObject _playerTorpedo = null;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_playerTorpedo, transform.position, transform.rotation);
        }
    }
}