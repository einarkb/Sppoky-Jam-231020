using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLights : MonoBehaviour
{
    public ParticleSystem ps;
    public GameObject spawnObject;
    private List<GameObject> instances = new List<GameObject>();
    private ParticleSystem.Particle[] particles;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[ps.main.maxParticles];
    }

    private void LateUpdate()
    {
        int nParticles = ps.GetParticles(particles);

        while (instances.Count < nParticles)
            instances.Add(Instantiate(spawnObject, ps.transform));

        bool isWorldSpace = (ps.main.simulationSpace == ParticleSystemSimulationSpace.World);
        for (int i = 0; i < instances.Count; i++)
        {
            if (i < nParticles)
            {
                if (isWorldSpace)
                    instances[i].transform.position = particles[i].position;
                else
                    instances[i].transform.localPosition = particles[i].position;
                instances[i].SetActive(true);
            }
            else   
                instances[i].SetActive(false);
        }
    }
}
