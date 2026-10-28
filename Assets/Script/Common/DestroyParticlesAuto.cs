using UnityEngine;

public class DestroyParticlesAuto : MonoBehaviour
{
    private ParticleSystem[] particles;

    private void Awake()
    {
        particles = GetComponentsInChildren<ParticleSystem>();
    }

    private void Update()
    {
        foreach ( var particle in particles )
        {
            if ( particle.isPlaying == true ) return;
        }

        Destroy(gameObject);
    }
}
