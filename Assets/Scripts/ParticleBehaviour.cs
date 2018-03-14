using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    public void OnParticleCollision(GameObject other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("CollisionHazard");
            other.GetComponent<PlayerBehaviour>().ReceiveDamage();
        }
    }
}
