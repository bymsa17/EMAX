using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    public ParticleSystem particles;
    public bool active;
    //public Transform pos;

    void Start ()
    {
        active = false;
        particles.Pause();
        //pos = this.transform;
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
        //GameData.gameState.position = pos;
    }
}
