using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkTrigger : MonoBehaviour
{
    public Transform trunk01;
    public Transform trunk02;
    public Vector2 trunkPos;
    public Vector2 direction;
    public float speed;

    // Use this for initialization
    void Start ()
    {
        //trunk = GameObject.FindGameObjectWithTag("Trunk").GetComponent<Transform>();
        trunk01 = this.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("TrunkTrigger");
            //trunkPos.y = trunk01.position.y + (direction.y * speed * Time.deltaTime);
        }
        //trunk01.position = trunkPos;
    }
}
