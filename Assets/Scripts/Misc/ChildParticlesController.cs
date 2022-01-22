using UnityEngine;

public class ChildParticlesController : MonoBehaviour
{
    private ParticleSystem[] _childParticles;

    private void Start()
    {
        _childParticles = gameObject.GetComponentsInChildren<ParticleSystem>();
    }

    public void OnDisable()
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
