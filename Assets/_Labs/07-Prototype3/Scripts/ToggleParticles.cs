using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleParticles : MonoBehaviour
{
    public GameObject[] particles = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        foreach (var particle in particles)
        {
            particle.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        foreach (var particle in particles)
        {
            particle.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        foreach (var particle in particles)
        {
            particle.SetActive(false);
        }
    }
}
