using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    public ParticleSystem particles;
    public bool active;

    void Start ()
    {
        active = false;
        particles.Pause();
    }
	
	void Update ()
    {
        if(active)
        {
            ActiveCheckpoint();
        }
	}

    public void ActiveCheckpoint()
    {
        particles.Play();
    }
}
