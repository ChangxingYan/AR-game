using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Particles : MonoBehaviour
{
    public ParticleSystem particleSystem;

    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }

    public void PlayParticle(Vector3 position)
    {
        particleSystem.gameObject.transform.position = position;
        particleSystem.Play();
    }
}
