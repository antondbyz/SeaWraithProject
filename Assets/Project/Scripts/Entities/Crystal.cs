using UnityEngine;

public class Crystal : MonoBehaviour, IInteractable, ISpawnable
{
    public InteractableType Type => InteractableType.Crystal;
    [SerializeField] private GameObject _collectedEffect;
    [SerializeField] private AudioClip[] _collectedAudios;
    
    public void Interact()
    {
        Instantiate(_collectedEffect, transform.position, Quaternion.identity);
        AudioPlayer.Instance.PlayRandomAudioOneShot(_collectedAudios);
        Disappear();
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
    }

    public void Spawn(Vector2 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
}
