using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkTrigger : MonoBehaviour
{
    public TrunkBehaviour trunk01;
    public TrunkBehaviour trunk02;

    public Animator animLight;
    public Animator animButton;

	//private AudioPlayer audioPlayer;

	void Start()
	{
        //audioPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("TrunkTrigger");

            trunk01.active = true;
            trunk02.active = true;
            animLight.SetTrigger("LightTrigger");
            animButton.SetTrigger("ButtonTrigger");
			//audioPlayer.PlaySFX(9, 1, Random.Range(0.9f, 1.1f));
        }
    }
}
