using UnityEngine;

public class ChildParticlesController : MonoBehaviour
{
    private ParticleSystem[] _childParticles;

    private void Awake()
    {
        _childParticles = gameObject.GetComponentsInChildren<ParticleSystem>();
    }

    private void OnDisable()
    {
        if(gameObject.activeInHierarchy)
        {
            for(int i = 0; i < _childParticles.Length; i++)
            {
                _childParticles[i].transform.parent = null;
                _childParticles[i].Stop();
            }
        }
    }
}
