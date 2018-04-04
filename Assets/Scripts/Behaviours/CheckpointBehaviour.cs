using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointBehaviour : MonoBehaviour
{
    public ParticleSystem particles;
    public bool active;
    public Vector3 pos;

    void Start ()
    {
        active = false;
        particles.Pause();
        pos = new Vector3(61, -7, 0);
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
        GameData.gameState.posX = pos.x;
        GameData.gameState.posY = pos.y;
        GameData.SaveGame(1);
        Debug.Log("Save Check Position");
    }
}
