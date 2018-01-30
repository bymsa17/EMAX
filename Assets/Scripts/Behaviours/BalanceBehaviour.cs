using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceBehaviour : MonoBehaviour
{
    public enum State { Medium, Up, Down };
    public State state = State.Medium;

    private PlayerBehaviour player;
    public Transform balance;
    public Vector2 direction;
    public float speed;
    public int weight;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();
        balance = this.transform;
    }
	
	// Update is called once per frame
	void Update ()
    {
        switch(state)
        {
            case State.Medium:
                break;
            case State.Up:
                break;
            case State.Down:
                break;
            default:
                break;
        }

        if(weight == 0)
        {
            direction.y = 0;
        }
        else if(weight == 1)
        {
            direction.y = 1;
        }
        else if(weight == -1)
        {
            direction.y = -1;
        }
        transform.Translate(direction * speed * Time.deltaTime);

        /*
        if(this.gameObject.tag == "Base1")
        {
            transform.Translate(distance * speed * Time.deltaTime);
        }*/
    }
}
