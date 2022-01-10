using UnityEngine;

public class Spawnable : MonoBehaviour
{
    [SerializeField] private ParticleSystem _bubblesParticles;
    
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
