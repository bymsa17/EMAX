using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBehaviour : MonoBehaviour
{
    private PlayerBehaviour player;
    //Collision2D collision;
    public Transform boxTransform;
    public Vector2 boxPos;
    public Vector2 distance;
    public float speed;

    

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        boxPos = boxTransform.position;
        //collision = GameObject.FindGameObjectWithTag("MetalBox").GetComponent<Collision2D>();
    }

    public void Ability()
    {

        if((player.transform.position.x + 5 >= boxTransform.position.x) && (player.transform.position.x < boxTransform.position.x))
        {
            if(this.gameObject.tag == "MetalBox")
            {
                boxPos.x = boxTransform.position.x + (distance.x * speed * Time.deltaTime);
            }
            else if(this.gameObject.tag == "WoodBox")
            {
                
                Debug.Log("DestroyWoodBox");
                
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject,1);
            }
        }
        else if((player.transform.position.x - 5 <= boxTransform.position.x) && (player.transform.position.x > boxTransform.position.x))
        {
            if(this.gameObject.tag == "MetalBox")
            {
                boxPos.x = boxTransform.position.x - (distance.x * speed * Time.deltaTime);
            }
            else if(this.gameObject.tag == "WoodBox")
            {
                Debug.Log("DestroyWoodBox");
                this.gameObject.SetActive(false);
                //Destroy(this.gameObject,1);
            }
        }
        /*else if (player.transform.position.x == boxTransform.position.x)
        {
                
        }*/
        boxTransform.position = boxPos;
    }
}
