using UnityEngine;

public class Spawnable : MonoBehaviour
{
    private ParticleSystem _bubblesParticles = null;

    private void Awake()
    {
        _bubblesParticles = transform.GetComponentInChildren<ParticleSystem>();
    }
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnDisable()
    {
        if(_bubblesParticles != null && gameObject.activeInHierarchy)
        {
            _bubblesParticles.transform.parent = null;
            _bubblesParticles.Stop();
        }
    }
}
